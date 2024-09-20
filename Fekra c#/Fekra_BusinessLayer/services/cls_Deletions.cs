using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.Deletions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Deletions
    {
        // completed testing.
        public static async Task<List<md_Deletions>?> GetAllAsync(int pageNumber)
        {
            return await cls_Deletions_D.GetAllAsync(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Deletions>?> GetByAdminAsync(int adminId, int pageNumber)
        {
            return await cls_Deletions_D.GetByAdminAsync(adminId, pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Deletions>?> GetByTableAsync(int tableId, int pageNumber)
        {
            return await cls_Deletions_D.GetByTableAsync(tableId, pageNumber);
        }

        // completed testing.
        public static async Task<md_Deletions?> GetByIdAsync(int deletionId)
        {
            return await cls_Deletions_D.GetByIdAsync(deletionId);
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_Deletions_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Admin_Async(int adminId)
        {
            return await cls_Deletions_D.GetPagesCount_Admin_Async(adminId);
        }

        // completed testing.
        public static async Task<int> GetPagesCount_All_Async()
        {
            return await cls_Deletions_D.GetPagesCount_All_Async();
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Table_Async(int tableId)
        {
            return await cls_Deletions_D.GetPagesCount_Table_Async(tableId);
        }
    }
}
