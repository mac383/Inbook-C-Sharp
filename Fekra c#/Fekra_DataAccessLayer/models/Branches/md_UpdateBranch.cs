using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Branches
{
    public class md_UpdateBranch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateBranch(int branchId, string branchName, int byAdmin)
        {
            BranchId = branchId;
            BranchName = branchName;
            ByAdmin = byAdmin;
        }
    }
}
