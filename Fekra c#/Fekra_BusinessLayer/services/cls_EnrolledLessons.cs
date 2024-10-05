using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Enrolled_Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_EnrolledLessons
    {
        // completed testing.
        public static async Task<List<md_EnrolledLessons>?> GetByEnrolledSectionAsync(int enrolledSectionId)
        {
            return await cls_EnrolledLessons_D.GetByEnrolledSectionAsync(enrolledSectionId);
        }

        // completed testing.
        public static async Task<md_EnrolledLesson?> GetByIdAsync(int enrolledLessonId)
        {
            return await cls_EnrolledLessons_D.GetByIdAsync(enrolledLessonId);
        }

        // completed testing.
        public static async Task<bool> DeleteFileAsync(int enrolledLessonId)
        {
            return await cls_EnrolledLessons_D.DeleteFileAsync(enrolledLessonId);
        }

        // completed testing.
        public static async Task<bool> DeleteNoteAsync(int enrolledLessonId)
        {
            return await cls_EnrolledLessons_D.DeleteNoteAsync(enrolledLessonId);
        }

        // completed testing.
        public static async Task<bool> IsFileExistAsync(string fileName)
        {
            return await cls_EnrolledLessons_D.IsFileExistAsync(fileName);
        }

        // completed testing.
        public static async Task<bool> SetAsCompletedAsync(int enrolledLessonId)
        {
            return await cls_EnrolledLessons_D.SetAsCompletedAsync(enrolledLessonId);
        }

        // completed testing.
        public static async Task<bool> SetFileAsync(int enrolledLessonId, string fileTitle, string fileURL, string fileName)
        {
            return await cls_EnrolledLessons_D.SetFileAsync(enrolledLessonId, fileTitle, fileURL, fileName);
        }

        // completed testing.
        public static async Task<bool> SetNoteAsync(int enrolledLessonId, string note)
        {
            return await cls_EnrolledLessons_D.SetNoteAsync(enrolledLessonId, note);
        }
    }
}
