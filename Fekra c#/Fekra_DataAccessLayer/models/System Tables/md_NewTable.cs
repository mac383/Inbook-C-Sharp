using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.System_Tables
{
    public class md_NewTable
    {
        public string TableName { get; set; }
        public int ByAdmin { get; set; }

        public md_NewTable(string tableName, int byAdmin)
        {
            TableName = tableName;
            ByAdmin = byAdmin;
        }
    }
}
