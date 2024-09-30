using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Branches
{
    public class md_Branches
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public md_Branches(int branchId, string branchName)
        {
            BranchId = branchId;
            BranchName = branchName;
        }
    }
}
