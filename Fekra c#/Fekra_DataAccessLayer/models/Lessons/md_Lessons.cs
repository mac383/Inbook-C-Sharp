using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Lessons
{
    public class md_Lessons
    {
        public int LessonId { get; set; }
        public string LessonTitle { get; set; }
        public string SectionName { get; set; }

        public md_Lessons(int lessonId, string lessonTitle, string sectionName)
        {
            LessonId = lessonId;
            LessonTitle = lessonTitle;
            SectionName = sectionName;
        }
    }
}
