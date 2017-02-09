using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using System.Text;

namespace GAP.Frederik.SuperZapatos.WebAPI.Filters
{
    public class ZapatosAPIAuthorizeAttribute
        : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            {
                if(authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                     !string.IsNullOrEmpty(authHeader.Parameter))
                {
                    var rawCredentials = authHeader.Parameter;
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));
                    var split = credentials.Split(':');
                    var username = split[0];
                    var password = split[1];

                    if (username == "my_user" && password == "my_password")
                        return;
                }
            }


            HandleUnauthorized(actionContext);
        }

        void HandleUnauthorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate",
                                                "Basic Scheme='SuperZapatos' location='http://localhost:54895/account/login'");
        }
    }
}