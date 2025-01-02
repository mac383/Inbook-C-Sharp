using Fekra_DataAccessLayer.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_AIRequestLimits
    {
        public static async Task<bool> CheckIfLimitExistsAsync(int userId)
        {
            return await cls_AIRequestLimits_D.CheckIfLimitExistsAsync(userId);
        }

        public static async Task<bool> ResetLimitAsync(int userId)
        {
            return await CheckIfLimitExistsAsync(userId) ? false : await cls_AIRequestLimits_D.ResetLimitAsync(userId);
        }

        public static async Task<bool> DecrementRemainingRequestsAsync(int userId)
        {
            return await cls_AIRequestLimits_D.DecrementRemainingRequestsAsync(userId);
        }

        public static async Task<int> GetRemainingRequestsAsync(int userId)
        {
            return await cls_AIRequestLimits_D.GetRemainingRequestsAsync(userId);
        }
    }
}
