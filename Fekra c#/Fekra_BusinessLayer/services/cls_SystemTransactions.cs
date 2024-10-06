using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.SystemTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_SystemTransactions
    {
        // completed testing.
        public static async Task<List<md_SystemTransactions>?> GetByTarget(int targetId, string tableName)
        {
            return await cls_SystemTransactions_D.GetByTarget(targetId, tableName);
        }
    }
}
