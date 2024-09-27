using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users
{
    public class md_Users
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string BranchName { get; set; }
        public string? ProfileImageURL { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime RegistrationDate { get; set; }

        public md_Users
            (
                int userId, string fullName, string userName, string branchName,
                string? profileImageURL, bool isDeleted, DateTime registrationDate
            )
        {
            UserId = userId;
            FullName = fullName;
            UserName = userName;
            BranchName = branchName;
            ProfileImageURL = profileImageURL;
            IsDeleted = isDeleted;
            RegistrationDate = registrationDate;
        }
    }
}
