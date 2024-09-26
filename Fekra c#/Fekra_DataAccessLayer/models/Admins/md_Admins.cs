using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Admins
{
    public class md_Admins
    {
        public int AdminId { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string? ProfileImageURL { get; set; }
        public string? ProfileImageName { get; set; }
        public bool IsDeleted { get; set; }

        public md_Admins
            (
                int adminId, bool isActive, string fullName, string userName,
                string? profileImageURL, string? profileImageName, bool isDeleted
            )
        {
            AdminId = adminId;
            IsActive = isActive;
            FullName = fullName;
            UserName = userName;
            ProfileImageURL = profileImageURL;
            ProfileImageName = profileImageName;
            IsDeleted = isDeleted;
        }
    }
}
