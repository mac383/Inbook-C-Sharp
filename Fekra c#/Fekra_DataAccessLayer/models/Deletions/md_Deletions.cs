﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Deletions
{
    public class md_Deletions
    {
        public int DeletionId { get; set; }
        public int TargetId { get; set; }
        public string TableName { get; set; }
        public DateTime DeletionDate { get; set; }
        public string DeletionData { get; set; }
        public string UserName { get; set; }

        public md_Deletions(int deletionId, int targetId, string tableName, DateTime deletionDate, string deletionData, string userName)
        {
            DeletionId = deletionId;
            TargetId = targetId;
            TableName = tableName;
            DeletionDate = deletionDate;
            DeletionData = deletionData;
            UserName = userName;
        }
    }
}
