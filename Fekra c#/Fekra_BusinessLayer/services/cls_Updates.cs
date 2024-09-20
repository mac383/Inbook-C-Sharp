using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Deletions;
using Fekra_DataAccessLayer.models.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Updates
    {
        // completed testing.
        public static async Task<List<md_Updates>?> GetAllAsync(int pageNumber)
        {
            return await cls_Updates_D.GetAllAsync(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Updates>?> GetByAdminAsync(int adminId, int pageNumber)
        {
            return await cls_Updates_D.GetByAdminAsync(adminId, pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Updates>?> GetByTableAsync(int tableId, int pageNumber)
        {
            return await cls_Updates_D.GetByTableAsync(tableId, pageNumber);
        }

        // completed testing.
        public static async Task<md_Updates?> GetByIdAsync(int updateId)
        {
            return await cls_Updates_D.GetByIdAsync(updateId);
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_Updates_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Admin_Async(int adminId)
        {
            return await cls_Updates_D.GetPagesCount_Admin_Async(adminId);
        }

        // completed testing.
        public static async Task<int> GetPagesCount_All_Async()
        {
            return await cls_Updates_D.GetPagesCount_All_Async();
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Table_Async(int tableId)
        {
            return await cls_Updates_D.GetPagesCount_Table_Async(tableId);
        }
    }
}
