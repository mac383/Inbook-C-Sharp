using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users
{
    public class md_ResetPassword
    {
        public int UserId { get; set; }
        public string Password { get; set; }

        public md_ResetPassword(int userId, string password)
        {
            UserId = userId;
            Password = password;
        }
    }
}
