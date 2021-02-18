using GitRepositoriesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace GitRepositories.Controllers
{
    public class UserWithTokenController : ApiController
    {
        public string UserName { get; set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            HttpRequestMessage request = controllerContext.Request;
            bool hasAuthKey = request.Headers.Contains("authKey");

            if (hasAuthKey)
            {
                // Check is authentication token exist in header
                string UserToken = request.Headers
                    .GetValues("authKey")?.FirstOrDefault();

                // Parse token and get encrypted username
                var simplePrinciple = new AuthBL().GetPrincipal(UserToken);
                var identity = simplePrinciple?.Identity as ClaimsIdentity;
                if (identity == null)
                    ThrowUnauthorized(); ;

                if (!identity.IsAuthenticated)
                    ThrowUnauthorized(); 

                var usernameClaim = identity.FindFirst(ClaimTypes.Name);
                UserName = usernameClaim?.Value;
                //******************************************

                if (string.IsNullOrEmpty(UserName))
                {
                    ThrowUnauthorized();
                }
                else
                {
                    base.Initialize(controllerContext);
                }
            }
            else
            {
                ThrowUnauthorized();
            }
        }

        private void ThrowUnauthorized()
        {
            var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            throw new HttpResponseException(msg);
        }
    }
}
