using GitRepositoriesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GitRepositories.Controllers
{
    public class RepositoriesController : ApiController
    { 
        [HttpGet]
        public HttpResponseMessage Repositories(string value)
        {
           return Request.CreateResponse(HttpStatusCode.OK, new RepositoryBL().GetRepositories(value));
        }
    }
}
