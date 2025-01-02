using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Acceptance_Rates_Files;
using Fekra_DataAccessLayer.models.AIUserMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_AIUserMemory
    {
        public static bool ValidateObj_UpdateMode(md_UpdateUserMemory userMemory)
        {
            if (userMemory.MemoryId <= 0)
                return false;

            return userMemory.RememberData.Length >= 0 && userMemory.RememberData.Length <= 3000;
        }

        public static async Task<bool> UpdateUserMemoryAsync(md_UpdateUserMemory updateData)
        {
            return ValidateObj_UpdateMode(updateData) ? await cls_AIUserMemory_D.UpdateUserMemoryAsync(updateData) : false;
        }

        public static async Task<md_UserMemory?> GetUserMemoryByUserIdAsync(int userId)
        {
            return await cls_AIUserMemory_D.GetUserMemoryByUserIdAsync(userId);
        }
    }
}
