using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Users
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewUser user)
        {
            if (user.BranchId <= 0)
                return false;

            if (!Validation.CheckLength(1, 25, user.FullName))
                return false;

            if (!Validation.IsEmailValid(user.Email))
                return false;

            if (!Validation.IsUsernameValid(user.UserName))
                return false;

            if (!Validation.IsPasswordValid(user.Password))
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_Users>?> GetAllAsync(int pageNumber)
        {
            return await cls_Users_D.GetAllAsync(pageNumber);
        }

        // completed testing.
        public static async Task<md_UserAuth?> GetByAuthAsync(string userNameOrEmail, string password)
        {
            return await cls_Users_D.GetByAuthAsync(userNameOrEmail, password);
        }

        // completed testing.
        public static async Task<List<md_Users>?> GetByFullNameAsync(string fullName)
        {
            return await cls_Users_D.GetByFullNameAsync(fullName);
        }

        // completed testing.
        public static async Task<md_User?> GetByIdAsync(int userId)
        {
            return await cls_Users_D.GetByIdAsync(userId);
        }

        // completed testing.
        public static async Task<md_Users?> GetByUserNameOrEmailAsync(string userNameOrEmail)
        {
            return await cls_Users_D.GetByUserNameOrEmailAsync(userNameOrEmail);
        }

        // completed testing.
        public static async Task<List<md_Users>?> GetDeletionsAsync(int pageNumber)
        {
            return await cls_Users_D.GetDeletionsAsync(pageNumber);
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_Users_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<int> GetDeletionsCountAsync()
        {
            return await cls_Users_D.GetDeletionsCountAsync();
        }

        // completed testing.
        public static async Task<int> GetPagesCountAllAsync()
        {
            return await cls_Users_D.GetPagesCountAllAsync();
        }

        // completed testing.
        public static async Task<int> GetPagesCountDeletionsAsync()
        {
            return await cls_Users_D.GetPagesCountDeletionsAsync();
        }

        // completed testing.
        public static async Task<int> GetCountByBranchAsync(int branchId)
        {
            return await cls_Users_D.GetCountByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<bool> DeleteImageAsync(int userId)
        {
            return await cls_Users_D.DeleteImageAsync(userId);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewUser user)
        {
            if (!ValidateObj_NewMode(user))
                return -1;

            user.Password = Encryption.HashEncrypt(user.Password);
            return await cls_Users_D.NewAsync(user);
        }

        // completed testing.
        public static async Task<bool> SetEmailAsync(int userId, string email)
        {
            return await cls_Users_D.SetEmailAsync(userId, email);
        }

        // completed testing.
        public static async Task<bool> SetFullNameAsync(int userId, string fullName)
        {
            return await cls_Users_D.SetFullNameAsync(userId, fullName);
        }

        // completed testing.
        public static async Task<bool> SetImageAsync(int userId, string imageURL, string imageName)
        {
            return await cls_Users_D.SetImageAsync(userId, imageURL, imageName);
        }

        // completed testing.
        public static async Task<bool> SetPasswordAsync(int userId, string password)
        {
            password = Encryption.HashEncrypt(password);
            return await cls_Users_D.SetPasswordAsync(userId, password);
        }

        // completed testing.
        public static async Task<bool> SetUserNameAsync(int userId, string userName)
        {
            return await cls_Users_D.SetUserNameAsync(userId, userName);
        }

        // completed testing.
        public static async Task<bool> IsEmailExistAsync(string email)
        {
            return await cls_Users_D.IsEmailExistAsync(email);
        }

        // completed testing.
        public static async Task<bool> IsImageNameExistAsync(string imageName)
        {
            return await cls_Users_D.IsImageNameExistAsync(imageName);
        }

        // completed testing.
        public static async Task<bool> IsUserNameExistAsync(string userName)
        {
            return await cls_Users_D.IsUserNameExistAsync(userName);
        }

        // completed testing.
        public static async Task<(int TotalUsers, int TotalUsersThisMonth)> GetUsersAnalyticsAsync()
        {
            return await cls_Users_D.GetUsersAnalyticsAsync();
        }
    }
}
