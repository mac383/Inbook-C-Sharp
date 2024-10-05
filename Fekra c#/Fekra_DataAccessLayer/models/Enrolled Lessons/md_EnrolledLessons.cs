using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Enrolled_Lessons
{
    public class md_EnrolledLessons
    {
        public int EnrolledLessonId { get; set; }
        public string LessonTitle { get; set; }
        public string? Note { get; set; }
        public bool IsCompleted { get; set; }
        public bool? HasFile { get; set; }

        public md_EnrolledLessons
            (
                int enrolledLessonId, string lessonTitle, string? note, 
                bool isCompleted, bool? hasFile
            )
        {
            EnrolledLessonId = enrolledLessonId;
            LessonTitle = lessonTitle;
            Note = note;
            IsCompleted = isCompleted;
            HasFile = hasFile;
        }
    }
}
