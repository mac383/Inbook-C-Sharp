using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Enrolled_Courses
{
    public class md_NewEnrolledCourse
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public md_NewEnrolledCourse(int userId, int courseId)
        {
            UserId = userId;
            CourseId = courseId;
        }
    }
}
