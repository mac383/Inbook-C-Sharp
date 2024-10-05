using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Enrolled_Lessons
{
    public class md_EnrolledLesson
    {
        public int EnrolledLessonId { get; set; }
        public string LessonTitle { get; set; }
        public string VideoURL { get; set; }
        public string? Note { get; set; }
        public bool IsCompleted { get; set; }
        public string? FileTitle { get; set; }
        public string? FileURL { get; set; }
        public string? FileName { get; set; }
        
        public md_EnrolledLesson
            (
                int enrolledLessonId, string lessonTitle, string videoURL, string? note,
                bool isCompleted, string? fileTitle, string? fileURL, string? fileName
            )
        {
            EnrolledLessonId = enrolledLessonId;
            LessonTitle = lessonTitle;
            VideoURL = videoURL;
            Note = note;
            IsCompleted = isCompleted;
            FileTitle = fileTitle;
            FileURL = fileURL;
            FileName = fileName;
        }
    }
}
