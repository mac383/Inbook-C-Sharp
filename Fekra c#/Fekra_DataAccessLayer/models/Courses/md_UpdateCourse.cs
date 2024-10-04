using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Courses
{
    public class md_UpdateCourse
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string? Description { get; set; }
        public string TeacherName { get; set; }
        public int BranchId { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateCourse
            (
                int courseId, string courseTitle, string? description,
                string teacherName, int branchId, int byAdmin
            )
        {
            CourseId = courseId;
            CourseTitle = courseTitle;
            Description = description;
            TeacherName = teacherName;
            BranchId = branchId;
            ByAdmin = byAdmin;
        }
    }
}
