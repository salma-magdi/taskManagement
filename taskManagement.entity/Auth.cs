using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManagementDomain
{
    public class Auth
    {

        
        public bool IsAuthenticated {  get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public List<string> Roles { get; set; } = new();
        public string token { get; set; }
        public DateTime expireOn {  get; set; }

    }
}
