using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Typical_Questions_Types
{
    public class md_NewTypicalQuestionType
    {
        public string Type { get; set; }
        public int ByAdmin { get; set; }

        public md_NewTypicalQuestionType(string type, int byAdmin)
        {
            Type = type;
            ByAdmin = byAdmin;
        }
    }
}
