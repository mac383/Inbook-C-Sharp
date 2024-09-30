using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Branches
{
    public class md_NewBranch
    {
        public string BranchName { get; set; }
        public int ByAdmin { get; set; }

        public md_NewBranch(string branchName, int byAdmin)
        {
            BranchName = branchName;
            ByAdmin = byAdmin;
        }
    }
}
