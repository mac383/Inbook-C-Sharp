using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Courses
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewCourse course)
        {
            if (!Validation.CheckLength(1, 250, course.CourseTitle))
                return false;

            if (!string.IsNullOrEmpty(course.Description))
                if (!Validation.CheckLength(1, 250, course.Description))
                    return false;

            if (!Validation.CheckLength(1, 100, course.TeacherName))
                return false;

            if (course.BranchId <= 0)
                return false;

            if (course.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateCourse course)
        {
            if (course.CourseId <= 0)
                return false;

            if (!Validation.CheckLength(1, 250, course.CourseTitle))
                return false;

            if (!string.IsNullOrEmpty(course.Description))
                if (!Validation.CheckLength(1, 250, course.Description))
                    return false;

            if (!Validation.CheckLength(1, 100, course.TeacherName))
                return false;

            if (course.BranchId <= 0)
                return false;

            if (course.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<int> GetActivesCountAsync()
        {
            return await cls_Courses_D.GetActivesCountAsync();
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_Courses_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<int> GetInActivesCountAsync()
        {
            return await cls_Courses_D.GetInActivesCountAsync();
        }

        // completed testing.
        public static async Task<List<md_ActiveCourses>?> GetActivesByBranchAsync(int branchId)
        {
            return await cls_Courses_D.GetActivesByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<List<md_Courses>?> GetAllByBranchAsync(int branchId)
        {
            return await cls_Courses_D.GetAllByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<md_Courses?> GetByIdAsync(int courseId)
        {
            return await cls_Courses_D.GetByIdAsync(courseId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int courseId, int byAdmin)
        {
            return await cls_Courses_D.DeleteAsync(courseId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> DeleteCourseCoverAsync(int courseId, int byAdmin)
        {
            return await cls_Courses_D.DeleteCourseCoverAsync(courseId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsCourseHasRelationsAsync(int courseId)
        {
            return await cls_Courses_D.IsCourseHasRelationsAsync(courseId);
        }

        // completed testing.
        public static async Task<bool> IsCoverExistAsync(string coverName)
        {
            return await cls_Courses_D.IsCoverExistAsync(coverName);
        }

        // completed testing.
        public static async Task<bool> SetAsActiveAsync(int courseId, int byAdmin)
        {
            return await cls_Courses_D.SetAsActiveAsync(courseId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetAsInActiveAsync(int courseId, int byAdmin)
        {
            return await cls_Courses_D.SetAsInActiveAsync(courseId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetCoverAsync(int courseId, string imageURL, string imageName, int byAdmin)
        {
            return await cls_Courses_D.SetCoverAsync(courseId, imageURL, imageName, byAdmin);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewCourse course)
        {
            if (!ValidateObj_NewMode(course))
                return -1;

            return await cls_Courses_D.NewAsync(course);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateCourse course)
        {
            if (!ValidateObj_UpdateMode(course))
                return false;

            return await cls_Courses_D.UpdateAsync(course);
        }
    }
}
