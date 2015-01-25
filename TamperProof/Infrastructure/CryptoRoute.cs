using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using TamperProof.Models;

namespace TamperProof.Infrastructure
{
    public class CryptoRoute : Route
    {
        public CryptoRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) 
            : base(url, defaults, routeHandler)
        {
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            // Get the base class to build the route data
            var routeData = base.GetRouteData(httpContext);

            // Url not matched
            if (routeData == null) return null;

            // All ids are supposed to be encrypted. Decrypt it!
            if (routeData.Values["id"] != System.Web.Mvc.UrlParameter.Optional)
            {
                string encryptedId = (string)routeData.Values["id"];
                byte[] byteId = HttpServerUtility.UrlTokenDecode(encryptedId);

                if (byteId == null) return null;

                AesCryptography helper = new AesCryptography();
                string id = helper.DecryptStringFromBytes(byteId);
                
                // Modify id value for controller to see it as normal
                routeData.Values["id"] = id;
            }

            return routeData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            // Get id from route data
            string id = values["id"] == null ? string.Empty : values["id"].ToString();

            if (!string.IsNullOrWhiteSpace(id))
            {
                // Encrypt and url encode id
                AesCryptography helper = new AesCryptography();
                byte[] encryptedId = helper.EncryptStringToBytes(id);

                values["id"] = HttpServerUtility.UrlTokenEncode(encryptedId);
            }

            return  base.GetVirtualPath(requestContext, values);
        }
    }
}