using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Typical_Questions_Types
{
    public class md_TypicalQuestionsTypes
    {
        public int TypeId { get; set; }
        public string Type { get; set; }

        public md_TypicalQuestionsTypes(int typeId, string type)
        {
            TypeId = typeId;
            Type = type;
        }
    }
}
