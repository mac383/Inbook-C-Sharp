using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Enrolled_Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_EnrolledCourses
    {
        public static bool ValidateObj_NewMode(md_NewEnrolledCourse enrolledCourse)
        {
            if (enrolledCourse.UserId <= 0)
                return false;

            if (enrolledCourse.CourseId <= 0)
                return false;

            return true;
        }

        //completed testing.
        public static async Task<List<md_EnrolledCourses>?> GetByUserAsync(int userId)
        {
            return await cls_EnrolledCourses_D.GetByUserAsync(userId);
        }

        //completed testing.
        public static async Task<md_EnrolledCourse?> GetByIdAsync(int enrolledCourseId)
        {
            return await cls_EnrolledCourses_D.GetByIdAsync(enrolledCourseId);
        }

        //completed testing.
        public static async Task<bool> DeleteAsync(int enrolledCourseId)
        {
            return await cls_EnrolledCourses_D.DeleteAsync(enrolledCourseId);
        }

        //completed testing.
        public static async Task<bool> IsUserEnrolledToCourseAsync(int userId, int courseId)
        {
            return await cls_EnrolledCourses_D.IsUserEnrolledToCourseAsync(userId, courseId);
        }

        //completed testing.
        public static async Task<int> NewAsync(md_NewEnrolledCourse course)
        {
            if (!ValidateObj_NewMode(course))
                return -1;

            return await cls_EnrolledCourses_D.NewAsync(course);
        }
    }
}
