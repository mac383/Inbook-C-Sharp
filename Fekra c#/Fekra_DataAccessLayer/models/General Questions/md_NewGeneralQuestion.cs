using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.General_Questions
{
    public class md_NewGeneralQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int ByAdmin { get; set; }

        public md_NewGeneralQuestion(string question, string answer, int byAdmin)
        {
            Question = question;
            Answer = answer;
            ByAdmin = byAdmin;
        }
    }
}
