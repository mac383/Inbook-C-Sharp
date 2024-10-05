using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Enrolled_Courses
{
    public class md_EnrolledCourse
    {
        public int EnrolledCourseId { get; set; }
        public string CourseTitle { get; set; }
        public string? Description { get; set; }
        public string TeacherName { get; set; }
        public string? CoverURL { get; set; }
        public string? CoverName { get; set; }
        public string BranchName { get; set; }
        public bool IsCompleted { get; set; }
        public byte CompletionRate { get; set; }

        public md_EnrolledCourse
            (
                int enrolledCourseId, string courseTitle, string? description, string teacherName,
                string? coverURL, string? coverName, string branchName, bool isCompleted, byte completionRate
            )
        {
            EnrolledCourseId = enrolledCourseId;
            CourseTitle = courseTitle;
            Description = description;
            TeacherName = teacherName;
            CoverURL = coverURL;
            CoverName = coverName;
            BranchName = branchName;
            IsCompleted = isCompleted;
            CompletionRate = completionRate;
        }
    }
}
