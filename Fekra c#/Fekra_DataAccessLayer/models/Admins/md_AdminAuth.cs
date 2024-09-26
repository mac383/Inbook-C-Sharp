using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Admins
{
    public class md_AdminAuth
    {
        public int AdminId { get; set; }
        public long Permissions { get; set; }
        public string? Description { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? ProfileImageURL { get; set; }
        public string? ProfileImageName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public md_AdminAuth
            (
                int adminId, long permissions, string? description, string fullName, string email,
                string userName, string password, string? profileImageURL, string? profileImageName, DateTime registrationDate
            )
        {
            AdminId = adminId;
            Permissions = permissions;
            Description = description;
            FullName = fullName;
            Email = email;
            UserName = userName;
            Password = password;
            ProfileImageURL = profileImageURL;
            ProfileImageName = profileImageName;
            RegistrationDate = registrationDate;
        }
    }
}
