using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models
{
    public class md_GeneralQuestions
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public md_GeneralQuestions(int questionId, string question, string answer)
        {
            QuestionId = questionId;
            Question = question;
            Answer = answer;
        }
    }
}
