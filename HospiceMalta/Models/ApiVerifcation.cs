using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace HospiceMalta.Models
{
    public class ApiVerifcation: ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //actionContext.Request.RequestUri
            //actionContext.Request.RequestUri.Query
            //actionContext.Request.RequestUri.Headers

            var res = actionContext.Request.Headers.GetValues("apikey");

            if (res.Equals("9CBC3820-D12B-4532-811A-427212AAF3E6"))
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

        }
    }
}