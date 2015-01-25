using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TamperProof.Models;

namespace TamperProof.Infrastructure
{
    public class UserRoute : RouteBase
    {
        /// <summary>
        /// Deal with incoming URL
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData result = null;

            var segments = httpContext.Request.AppRelativeCurrentExecutionFilePath.Split(new[] {'/'});
            if(segments.Any(s => s.Equals("user", StringComparison.OrdinalIgnoreCase)))
            {
                try
                {
                    int idx = Array.FindIndex(segments, p => p.Equals("user", StringComparison.OrdinalIgnoreCase));
                    result = new RouteData(this, new MvcRouteHandler());
                    result.Values.Add("controller", segments[idx]);
                    result.Values.Add("action", segments[idx + 1]);
                    string urlEncodedId = segments[idx + 2];
                    // id decrypt
                    AesCryptography helper = new AesCryptography();
                    string id = helper.DecryptStringFromBytes(Convert.FromBase64String(urlEncodedId));
                    result.Values.Add("id", id);
                }
                catch
                {
                    result = null;
                }
            }

            return result;
        }

        /// <summary>
        /// Generate outgoing URL
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData result = null;

            if (values["controller"].ToString().Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    // encode id
                    string id = values["id"].ToString();
                    AesCryptography helper = new AesCryptography();
                    byte[] encryptedId = helper.EncryptStringToBytes(id);
                    string relPath = String.Format("{0}/{1}/{2}", values["controller"], values["action"], Convert.ToBase64String(encryptedId));
                    result = new VirtualPathData(this, new UrlHelper(requestContext).Content(relPath));
                }
                catch
                {
                    result = null;
                }
            }

            return result;
        }
    }
}