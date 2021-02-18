using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRepositoryModel
{
    public class Repository
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public RepositoryOwner owner { get; set; }
    }
}
