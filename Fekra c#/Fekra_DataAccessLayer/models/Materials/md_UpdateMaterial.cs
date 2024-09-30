using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Materials
{
    public class md_UpdateMaterial
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateMaterial(int materialId, string materialName, int byAdmin)
        {
            MaterialId = materialId;
            MaterialName = materialName;
            ByAdmin = byAdmin;
        }
    }
}
