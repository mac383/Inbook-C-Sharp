using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users
{
    public class md_AuthRequest
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }

        public md_AuthRequest(string userNameOrEmail, string password)
        {
            UserNameOrEmail = userNameOrEmail;
            Password = password;
        }
    }
}
