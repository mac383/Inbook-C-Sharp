using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Updates
{
    public class md_Updates
    {
        public int UpdateId { get; set; }
        public string TableName { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedData { get; set; }
        public string UserName { get; set; }

        public md_Updates(int updateId, string tableName, DateTime updateDate, string updatedData, string userName)
        {
            UpdateId = updateId;
            TableName = tableName;
            UpdateDate = updateDate;
            UpdatedData = updatedData;
            UserName = userName;
        }
    }
}
