using GitRepositoriesBL;
using GitRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.SessionState;

namespace GitRepositories.Controllers
{
    public class BookmarkController : UserWithTokenController
    {
        [HttpPost]
        public IHttpActionResult BoookmarkRepository(PostRepositoryRequest request)
        {
            new RepositoryBL().BookmarkRepository(UserName, request.Id, request.Action);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetBookmarks()
        {
            return Ok(new RepositoryBL().GetBookmarksByUserName(UserName));
        }
    }
}
