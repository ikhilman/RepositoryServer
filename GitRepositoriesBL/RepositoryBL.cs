using GitRepositoryModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GitRepositoriesBL
{
    public class RepositoryBL
    {
        /// <summary>
        /// Get Repositories by user request string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public RepositoryResponse GetRepositories(string value)
        {
            // GitHub search repositories url
            string uri = "https://api.github.com/search/repositories?q=" + value;
            RepositoryResponse Response = null;
            try
            {
                string RepositoriesResponse = new HttpHandler().Get(uri);
                Response = JsonConvert.DeserializeObject<RepositoryResponse>(RepositoriesResponse);
            }
            catch (Exception )
            {
            }
            return Response;
        }

        /// <summary>
        /// Add remove bookmarks to cache
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Repository"></param>
        /// <param name="Action"></param>
        public void BookmarkRepository(string UserName, int Repository, BookmarkAction Action)
        {
            Dictionary<string, List<int>> dic = HttpContext.Current.Cache["Repositories"] as Dictionary<string, List<int>>;

            if (dic != null)
            {
                if (dic.ContainsKey(UserName))
                {
                    List<int> UserRepos = dic[UserName];
                    if (Action == BookmarkAction.Add)
                    {
                        UserRepos.Add(Repository);
                    }
                    else 
                    {
                        UserRepos.Remove(UserRepos.Where(r => r == Repository).FirstOrDefault());
                    }
                    dic[UserName] = UserRepos;
                }
                else
                {
                    dic.Add(UserName, new List<int>() { Repository });
                }
                HttpContext.Current.Cache["Repositories"] = dic;
            }
            else
            {
                dic = new Dictionary<string, List<int>>();
                dic.Add(UserName, new List<int>() { Repository });
                HttpContext.Current.Cache["Repositories"] = dic;
            }
        }


        /// <summary>
        /// Get stored user bookmarks
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public List<int> GetBookmarksByUserName(string UserName)
        {
            Dictionary<string, List<int>> dic = HttpContext.Current.Cache["Repositories"] as Dictionary<string, List<int>>;
            List<int> Bookmarks = new List<int>();
            if (dic!=null && dic.ContainsKey(UserName))
            {
                Bookmarks = dic[UserName];
            }
            return Bookmarks;
        }
    }
}
