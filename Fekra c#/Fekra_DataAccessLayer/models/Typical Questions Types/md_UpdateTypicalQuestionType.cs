using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Typical_Questions_Types
{
    public class md_UpdateTypicalQuestionType
    {
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateTypicalQuestionType(int typeId, string type, int byAdmin)
        {
            TypeId = typeId;
            Type = type;
            ByAdmin = byAdmin;
        }
    }
}
