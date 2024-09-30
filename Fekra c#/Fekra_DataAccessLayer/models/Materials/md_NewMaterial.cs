using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Materials
{
    public class md_NewMaterial
    {
        public string MaterialName { get; set; }
        public int BranchId { get; set; }
        public int ByAdmin { get; set; }

        public md_NewMaterial(string materialName, int branchId, int byAdmin)
        {
            MaterialName = materialName;
            BranchId = branchId;
            ByAdmin = byAdmin;
        }
    }
}
