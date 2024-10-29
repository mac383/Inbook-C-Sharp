using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Admins
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewAdmin admin)
        {
            if (!Validation.IsInt(admin.Permissions.ToString()))
                return false;

            if (!Validation.CheckLength(1, 25, admin.FullName))
                return false;

            if (!Validation.IsEmailValid(admin.Email))
                return false;

            if (!Validation.IsUsernameValid(admin.UserName))
                return false;

            if (!Validation.IsPasswordValid(admin.Password))
                return false;

            if (admin.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_Admins_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<int> GetDeletionsCountAsync()
        {
            return await cls_Admins_D.GetDeletionsCountAsync();
        }

        // completed testing.
        public static async Task<int> GetInActivesCountAsync()
        {
            return await cls_Admins_D.GetInActivesCountAsync();
        }

        // completed testing.
        public static async Task<int> GetAllPagesCountAsync()
        {
            return await cls_Admins_D.GetAllPagesCountAsync();
        }

        // completed testing.
        public static async Task<int> GetDeletionsPagesCountAsync()
        {
            return await cls_Admins_D.GetDeletionsPagesCountAsync();
        }

        // completed testing.
        public static async Task<int> GetInActivesPagesCountAsync()
        {
            return await cls_Admins_D.GetInActivesPagesCountAsync();
        }

        // completed testing.
        public static async Task<List<md_Admins>?> GetAllAsync(int pageNumber)
        {
            return await cls_Admins_D.GetAllAsync(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Admins>?> GetByFullNameAsync(string fullName)
        {
            return await cls_Admins_D.GetByFullNameAsync(fullName);
        }

        // completed testing.
        public static async Task<List<md_Admins>?> GetDeletionsAsync(int pageNumber)
        {
            return await cls_Admins_D.GetDeletionsAsync(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Admins>?> GetInActivesAsync(int pageNumber)
        {
            return await cls_Admins_D.GetInActivesAsync(pageNumber);
        }

        // completed testing.
        public static async Task<md_AdminAuth?> GetByAuthAsync(string userNameOrEmail, string password)
        {
            return await cls_Admins_D.GetByAuthAsync(userNameOrEmail, password);
        }

        // completed testing.
        public static async Task<md_Admin?> GetByIdAsync(int adminId)
        {
            return await cls_Admins_D.GetByIdAsync(adminId);
        }

        // completed testing.
        public static async Task<md_Admins?> GetByUserNameOrEmailAsync(string userNameOrEmail)
        {
            return await cls_Admins_D.GetByUserNameOrEmailAsync(userNameOrEmail);
        }

        // completed testing.
        public static async Task<bool> ClearPermissionsAsync(int adminId, int byAdmin)
        {
            return await cls_Admins_D.ClearPermissionsAsync(adminId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int adminId, int byAdmin)
        {
            return await cls_Admins_D.DeleteAsync(adminId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> DeleteImageAsync(int adminId)
        {
            return await cls_Admins_D.DeleteImageAsync(adminId);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewAdmin admin)
        {
            if (!ValidateObj_NewMode(admin))
                return -1;

            admin.Password = Encryption.HashEncrypt(admin.Password);

            return await cls_Admins_D.NewAsync(admin);
        }

        // completed testing.
        public static async Task<bool> SetAsActiveAsync(int adminId, int byAdmin)
        {
            return await cls_Admins_D.SetAsActiveAsync(adminId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetAsInActiveAsync(int adminId, int byAdmin)
        {
            return await cls_Admins_D.SetAsInActiveAsync(adminId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetDescriptionAsync(int adminId, string? description, int byAdmin)
        {
            return await cls_Admins_D.SetDescriptionAsync(adminId, description, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetEmailAsync(int adminId, string email)
        {
            return await cls_Admins_D.SetEmailAsync(adminId, email);
        }

        // completed testing.
        public static async Task<bool> SetFullNameAsync(int adminId, string fullName)
        {
            return await cls_Admins_D.SetFullNameAsync(adminId, fullName);
        }

        // completed testing.
        public static async Task<bool> SetImageAsync(int adminId, string imageURL, string imageName)
        {
            return await cls_Admins_D.SetImageAsync(adminId, imageURL, imageName);
        }

        // completed testing.
        public static async Task<bool> SetPasswordAsync(int adminId, string password)
        {
            password = Encryption.HashEncrypt(password);
            return await cls_Admins_D.SetPasswordAsync(adminId, password);
        }

        // completed testing.
        public static async Task<bool> SetPermissionsAsync(int adminId, long permissions, int byAdmin)
        {
            return await cls_Admins_D.SetPermissionsAsync(adminId, permissions, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetUserNameAsync(int adminId, string userName)
        {
            return await cls_Admins_D.SetUserNameAsync(adminId, userName);
        }

        // completed testing.
        public static async Task<bool> IsEmailExistAsync(string email)
        {
            return await cls_Admins_D.IsEmailExistAsync(email);
        }

        // completed testing.
        public static async Task<bool> IsImageNameExistAsync(string imageName)
        {
            return await cls_Admins_D.IsImageNameExistAsync(imageName);
        }

        // completed testing.
        public static async Task<bool> IsUserNameExistAsync(string userName)
        {
            return await cls_Admins_D.IsUserNameExistAsync(userName);
        }
    }
}
