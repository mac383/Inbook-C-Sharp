using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users
{
    public class md_User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string? ProfileImageURL { get; set; }
        public string? ProfileImageName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string BranchName { get; set; }

        public md_User
            (
                int userId, string fullName, string email, string userName, string? profileImageURL,
                string? profileImageName, bool isDeleted, DateTime registrationDate, string branchName
            )
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            UserName = userName;
            ProfileImageURL = profileImageURL;
            ProfileImageName = profileImageName;
            IsDeleted = isDeleted;
            RegistrationDate = registrationDate;
            BranchName = branchName;
        }
    }
}
