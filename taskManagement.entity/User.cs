using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManagement.entity
{
public class User:BaseClass
    {
       
        public string email { get; set; }
        public string password { get; set; }
        public string passwordHash { get; set; }
        // nav properity
        public List<Project> projects { get; set; } = new List<Project>();

       
    }
}
