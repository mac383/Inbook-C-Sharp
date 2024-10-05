using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Lessons
{
    public class md_NewLesson
    {
        public string LessonTitle { get; set; }
        public string VideoURL { get; set; }
        public int SectionId { get; set; }
        public int ByAdmin { get; set; }

        public md_NewLesson
            (
                string lessonTitle, string videoURL, int sectionId, int byAdmin
            )
        {
            LessonTitle = lessonTitle;
            VideoURL = videoURL;
            SectionId = sectionId;
            ByAdmin = byAdmin;
        }
    }
}
