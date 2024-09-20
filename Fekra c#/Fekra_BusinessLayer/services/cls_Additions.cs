using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Additions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Additions
    {
        // completed testing.
        public static async Task<List<md_Additions>?> GetAllAsync(int pageNumber)
        {
            return await cls_Additions_D.GetAllAsync(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Additions>?> GetByAdminAsync(int adminId, int pageNumber)
        {
            return await cls_Additions_D.GetByAdminAsync(adminId, pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Additions>?> GetByTableAsync(int tableId, int pageNumber)
        {
            return await cls_Additions_D.GetByTableAsync(tableId, pageNumber);
        }

        // completed testing.
        public static async Task<md_Additions?> GetByIdAsync(int additionId)
        {
            return await cls_Additions_D.GetByIdAsync(additionId);
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_Additions_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Admin_Async(int adminId)
        {
            return await cls_Additions_D.GetPagesCount_Admin_Async(adminId);
        }

        // completed testing.
        public static async Task<int> GetPagesCount_All_Async()
        {
            return await cls_Additions_D.GetPagesCount_All_Async();
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Table_Async(int tableId)
        {
            return await cls_Additions_D.GetPagesCount_Table_Async(tableId);
        }
    }
}
