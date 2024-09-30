using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Materials
{
    public class md_Materials
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string BranchName { get; set; }

        public md_Materials(int materialId, string materialName, string branchName)
        {
            MaterialId = materialId;
            MaterialName = materialName;
            BranchName = branchName;
        }
    }
}
