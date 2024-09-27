using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users
{
    public class md_NewUser
    {
        public int BranchId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public md_NewUser(int branchId, string fullName, string email, string userName, string password)
        {
            BranchId = branchId;
            FullName = fullName;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
