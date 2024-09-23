using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Additions
{
    public class md_Additions
    {
        public int AdditionId { get; set; }
        public int TargetId { get; set; }
        public string TableName { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedData { get; set; }
        public string UserName { get; set; }

        public md_Additions(int additionId, int targetId, string tableName, DateTime addedDate, string addedData, string userName)
        {
            AdditionId = additionId;
            TargetId = targetId;
            TableName = tableName;
            AddedDate = addedDate;
            AddedData = addedData;
            UserName = userName;
        }

    }
}
