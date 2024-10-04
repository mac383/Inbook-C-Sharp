using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Courses
{
    public class md_ActiveCourses
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string? Description { get; set; }
        public string TeacherName { get; set; }
        public string? CoverURL { get; set; }
        public string? CoverName { get; set; }
        public string BranchName { get; set; }

        public md_ActiveCourses
            (
                int courseId, string courseTitle, string? description, string teacherName,
                string? coverURL, string? coverName, string branchName
            )
        {
            CourseId = courseId;
            CourseTitle = courseTitle;
            Description = description;
            TeacherName = teacherName;
            CoverURL = coverURL;
            CoverName = coverName;
            BranchName = branchName;
        }
    }
}
