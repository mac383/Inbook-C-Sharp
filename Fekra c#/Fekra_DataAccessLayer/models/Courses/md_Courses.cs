using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Courses
{
    public class md_Courses
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string? Description { get; set; }
        public string TeacherName { get; set; }
        public string? CoverURL { get; set; }
        public string? CoverName { get; set; }
        public bool IsActive { get; set; }
        public string BranchName { get; set; }

        public md_Courses
            (
                int courseId, string courseTitle, string? description, string teacherName,
                string? coverURL, string? coverName, bool isActive, string branchName
            )
        {
            CourseId = courseId;
            CourseTitle = courseTitle;
            Description = description;
            TeacherName = teacherName;
            CoverURL = coverURL;
            CoverName = coverName;
            IsActive = isActive;
            BranchName = branchName;
        }
    }
}
