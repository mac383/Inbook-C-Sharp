using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Materials
{
    public class md_MaterialsWhereHaveTypicalQuestions
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }

        public md_MaterialsWhereHaveTypicalQuestions(int materialId, string materialName)
        {
            MaterialId = materialId;
            MaterialName = materialName;
        }
    }
}
