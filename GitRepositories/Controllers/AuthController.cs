using GitRepositoriesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GitRepositories.Controllers
{
    public class AuthController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Auth(string UserName,string Password)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new AuthBL().AuthUser(UserName, Password));
        }
    }
}
