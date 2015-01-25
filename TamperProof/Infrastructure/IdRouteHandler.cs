using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;

namespace TamperProof.Infrastructure
{
    public class IdRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            //requestContext.RouteData.Values["id"]
            return base.GetHttpHandler(requestContext);
        }
    }
}