using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRepositoryModel
{
    public class PostRepositoryRequest
    {
        public int Id { get; set; }
        public BookmarkAction Action { get; set; }
    }
}
