using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Admins
{
    public class md_Admin
    {
        public int AdminId { get; set; }
        public bool IsActive { get; set; }
        public long Permissions { get; set; }
        public string? Description { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string? ProfileImageURL { get; set; }
        public string? ProfileImageName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime RegistrationDate { get; set; }

        public md_Admin
            (
                int adminId, bool isActive, long permissions, string? description, string fullName, string email,
                string userName, string? profileImageURL, string? profileImageName, bool isDeleted, DateTime registrationDate
            )
        {
            AdminId = adminId;
            IsActive = isActive;
            Permissions = permissions;
            Description = description;
            FullName = fullName;
            Email = email;
            UserName = userName;
            ProfileImageURL = profileImageURL;
            ProfileImageName = profileImageName;
            IsDeleted = isDeleted;
            RegistrationDate = registrationDate;
        }
    }
}
