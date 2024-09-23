using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.System_Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_SystemTables
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewTable table)
        {
            if (string.IsNullOrEmpty(table.TableName) || table.TableName.Length > 100)
                return false;

            if (table.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateTable table)
        {
            if (table.TableId <= 0)
                return false;

            if (string.IsNullOrEmpty(table.TableName) || table.TableName.Length > 100)
                return false;

            if (table.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int tableId, int byAdmin)
        {
            return await cls_SystemTables_D.DeleteAsync(tableId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsHasRelations(int tableId)
        {
            return await cls_SystemTables_D.IsHasRelations(tableId);
        }

        // completed testing.
        public static async Task<bool> IsTableNameExist(string tableName)
        {
            return await cls_SystemTables_D.IsTableNameExist(tableName);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewTable table)
        {
            if (!ValidateObj_NewMode(table))
                return -1;

            return await cls_SystemTables_D.NewAsync(table);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateTable table)
        {
            if (!ValidateObj_UpdateMode(table))
                return false;

            return await cls_SystemTables_D.UpdateAsync(table);
        }

        // completed testing.
        public static async Task<List<md_SystemTables>?> GetAllAsync()
        {
            return await cls_SystemTables_D.GetAllAsync();
        }

        // completed testing.
        public static async Task<md_SystemTables?> GetByIdAsync(int tableId)
        {
            return await cls_SystemTables_D.GetByIdAsync(tableId);
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_SystemTables_D.GetCountAsync();
        }
    }
}
