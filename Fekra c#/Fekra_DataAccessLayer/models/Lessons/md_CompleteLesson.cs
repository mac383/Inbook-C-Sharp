using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Lessons
{
    public class md_CompleteLesson
    {
        public string LessonTitle { get; set; }
        public string VideoURL { get; set; }
        public string VideoId { get; set; }
        public int SectionId { get; set; }
        public int ByAdmin { get; set; }

        public md_CompleteLesson
            (
                string lessonTitle, string videoURL, string videoId, int sectionId, int byAdmin
            )
        {
            LessonTitle = lessonTitle;
            VideoURL = videoURL;
            VideoId = videoId;
            SectionId = sectionId;
            ByAdmin = byAdmin;
        }
    }
}
