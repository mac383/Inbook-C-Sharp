using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Enrolled_Lessons
{
    public class md_newLessonFile (int enrolledLessonId, string fileTitle, string fileURL, string fileName)
    {
        public int EnrolledLessonId { get; set; } = enrolledLessonId;
        public string FileTitle { get; set; } = fileTitle;
        public string FileURL { get; set; } = fileURL;
        public string FileName { get; set; } = fileName;
    }
}
