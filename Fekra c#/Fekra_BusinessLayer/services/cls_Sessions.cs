using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Sessions;
using Fekra_DataAccessLayer.models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Sessions
    {
        public static bool ValidateObj_NewMode(md_NewSession session)
        {
            if (session.UserId <= 0)
                return false;

            if (!Validation.CheckLength(1, 100, session.Key))
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_Sessions>?> GetActiveSessionsAsync(int pageNumber)
        {
            return await cls_Sessions_D.GetActiveSessionsAsync(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Sessions>?> GetInActiveSessionsAsync(int pageNumber)
        {
            return await cls_Sessions_D.GetInActiveSessionsAsync(pageNumber);
        }

        // completed testing.
        public static async Task<string?> GetActiveSessionKeyAsync(int userId)
        {
            return await cls_Sessions_D.GetActiveSessionKeyAsync(userId);
        }

        // completed testing.
        public static async Task<int> GetActivesCountAsync()
        {
            return await cls_Sessions_D.GetActivesCountAsync();
        }

        // completed testing.
        public static async Task<int> GetInActivesCountAsync()
        {
            return await cls_Sessions_D.GetInActivesCountAsync();
        }

        // completed testing.
        public static async Task<int> GetSessionsPagesCountActivesAsync()
        {
            return await cls_Sessions_D.GetSessionsPagesCountActivesAsync();
        }

        // completed testing.
        public static async Task<int> GetSessionsPagesCountInActivesAsync()
        {
            return await cls_Sessions_D.GetSessionsPagesCountInActivesAsync();
        }

        // completed testing.
        public static async Task<bool> DeleteInActiveSessionsAsync()
        {
            return await cls_Sessions_D.DeleteInActiveSessionsAsync();
        }

        // completed testing.
        public static async Task<bool> IsSessionKeyActiveAsync(string key)
        {
            return await cls_Sessions_D.IsSessionKeyActiveAsync(key);
        }

        // completed testing.
        public static async Task<bool> IsSessionKeyExistAsync(string key)
        {
            return await cls_Sessions_D.IsSessionKeyExistAsync(key);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewSession session)
        {
            if (!ValidateObj_NewMode(session))
                return -1;

            return await cls_Sessions_D.NewAsync(session);
        }

        // completed testing.
        public static async Task<bool> SetSessionAsInActiveAsync(int userId)
        {
            return await cls_Sessions_D.SetSessionAsInActiveAsync(userId);
        }
    }
}
