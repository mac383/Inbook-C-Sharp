﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users
{
    public class md_UserAuth
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? ProfileImageURL { get; set; }
        public string? ProfileImageName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public md_UserAuth
            (
                int userId, string fullName, string email, string userName, string password, string? profileImageURL,
                string? profileImageName, DateTime registrationDate, int branchId, string branchName
            )
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            UserName = userName;
            Password = password;
            ProfileImageURL = profileImageURL;
            ProfileImageName = profileImageName;
            RegistrationDate = registrationDate;
            BranchId = branchId;
            BranchName = branchName;
        }
    }
}
