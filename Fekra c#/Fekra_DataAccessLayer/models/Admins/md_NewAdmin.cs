using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Admins
{
    public class md_NewAdmin
    {
        public long Permissions { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ByAdmin { get; set; }

        public md_NewAdmin(long permissions, string fullName, string email, string userName, string password, int byAdmin)
        {
            Permissions = permissions;
            FullName = fullName;
            Email = email;
            UserName = userName;
            Password = password;
            ByAdmin = byAdmin;
        }
    }
}
