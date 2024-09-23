using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.System_Tables
{
    public class md_UpdateTable
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateTable(int tableId, string tableName, int byAdmin)
        {
            TableId = tableId;
            TableName = tableName;
            ByAdmin = byAdmin;
        }
    }
}
