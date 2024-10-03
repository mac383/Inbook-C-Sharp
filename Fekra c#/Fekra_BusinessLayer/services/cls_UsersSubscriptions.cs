using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Users_Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_UsersSubscriptions
    {
        public static bool ValidateObj_NewMode(md_NewUserSubscription subscription)
        {
            if (subscription.UserId <= 0)
                return false;

            if (subscription.PlanId <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<int> GetActivesCount()
        {
            return await cls_UsersSubscriptions_D.GetActivesCountAsync();
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_UsersSubscriptions_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<int> GetInActivesCountAsync()
        {
            return await cls_UsersSubscriptions_D.GetInActivesCountAsync();
        }

        // completed testing.
        public static async Task<int> GetUsersSubscriptionsPagesCountActiveAsync()
        {
            return await cls_UsersSubscriptions_D.GetUsersSubscriptionsPagesCountActiveAsync();
        }

        // completed testing.
        public static async Task<int> GetUsersSubscriptionsPagesCountInActivesAsync()
        {
            return await cls_UsersSubscriptions_D.GetUsersSubscriptionsPagesCountInActivesAsync();
        }

        // completed testing.
        public static async Task<List<md_UsersSubscriptions>?> GetActivesAsync(int pageNumber)
        {
            return await cls_UsersSubscriptions_D.GetActivesAsync(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_UsersSubscriptions>?> GetInActivesAsync(int pageNumber)
        {
            return await cls_UsersSubscriptions_D.GetInActivesAsync(pageNumber);
        }

        // completed testing.
        public static async Task<md_UserSubscription?> GetActiveSubscriptionByUserAsync(int userId)
        {
            return await cls_UsersSubscriptions_D.GetActiveSubscriptionByUserAsync(userId);
        }

        // completed testing.
        public static async Task<md_UserSubscription?> GetSubscriptionByIdAsync(int subscriptionId)
        {
            return await cls_UsersSubscriptions_D.GetSubscriptionByIdAsync(subscriptionId);
        }

        // completed testing.
        public static async Task<bool> CheckUserSubscriptionAsync(int userId)
        {
            return await cls_UsersSubscriptions_D.CheckUserSubscriptionAsync(userId);
        }

        // completed testing.
        public static async Task<bool> IsUserHasActiveSubscriptionAsync(int userId)
        {
            return await cls_UsersSubscriptions_D.IsUserHasActiveSubscriptionAsync(userId);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewUserSubscription subscription)
        {
            if (!ValidateObj_NewMode(subscription))
                return -1;

            return await cls_UsersSubscriptions_D.NewAsync(subscription);
        }
    }
}
