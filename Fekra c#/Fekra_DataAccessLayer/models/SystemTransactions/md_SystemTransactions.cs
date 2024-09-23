using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.SystemTransactions
{
    public class md_SystemTransactions
    {
        public int TransactionId { get; set; }
        public int TargetId { get; set; }
        public string TableName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionData { get; set; }
        public string UserName { get; set; }
        public byte TransactionType { get; set; }

        public md_SystemTransactions
            (
                int transactionId, int targetId, string tableName, DateTime transactionDate, 
                string transactionData, string userName, byte transactionType
            )
        {
            TransactionId = transactionId;
            TargetId = targetId;
            TableName = tableName;
            TransactionDate = transactionDate;
            TransactionData = transactionData;
            UserName = userName;
            TransactionType = transactionType;
        }
    }
}
