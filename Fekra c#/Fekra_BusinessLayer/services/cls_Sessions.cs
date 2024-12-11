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
        public static async Task<string?> NewAsync(int userId)
        {
            if (userId <= 0)
                return null;

            string _key = KeyProvider.GetPart(50, KeyProvider.EN_KeyType.NumbersLetters);

            while (await IsSessionKeyExistAsync(_key))
            {
                _key = KeyProvider.GetPart(50, KeyProvider.EN_KeyType.NumbersLetters);
            }

            int insertedId = await cls_Sessions_D.NewAsync(userId, _key);
            return insertedId > 0 ? _key : null;
        }

        // completed testing.
        public static async Task<bool> SetSessionAsInActiveAsync(int userId)
        {
            return await cls_Sessions_D.SetSessionAsInActiveAsync(userId);
        }

        // completed testing.
        public static async Task<(int TotalSessions, int ActiveSessions, int InActiveSessions)> GetUserSessionsAnalyticsAsync(int userId)
        {
            return await cls_Sessions_D.GetUserSessionsAnalyticsAsync(userId);
        }

        // completed testing.
        public static async Task<(int TotalSessions, int ActiveSessions, int InActiveSessions)> GetUsersSessionsAnalyticsAsync()
        {
            return await cls_Sessions_D.GetUsersSessionsAnalyticsAsync();
        }
    }
}
