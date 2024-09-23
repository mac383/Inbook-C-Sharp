using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.System_Tables
{
    public class md_SystemTables
    {
        public int TableId { get; set; }
        public string TableName { get; set; }

        public md_SystemTables(int tableId, string tableName)
        {
            TableId = tableId;
            TableName = tableName;
        }
    }
}
