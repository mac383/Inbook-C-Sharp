using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.General_Questions
{
    public class md_UpdateGeneralQuestion
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateGeneralQuestion(int questionId, string question, string answer, int byAdmin)
        {
            QuestionId = questionId;
            Question = question;
            Answer = answer;
            ByAdmin = byAdmin;
        }
    }
}
