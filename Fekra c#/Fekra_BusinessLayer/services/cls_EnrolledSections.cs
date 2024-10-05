using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Enrolled_Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_EnrolledSections
    {
        //completed testing.
        public static async Task<List<md_EnrolledSections>?> GetByEnrolledCourseAsync(int enrolledCourseId)
        {
            return await cls_EnrolledSections_D.GetByEnrolledCourseAsync(enrolledCourseId);
        }

        //completed testing.
        public static async Task<md_EnrolledSection?> GetByIdAsync(int enrolledSectionId)
        {
            return await cls_EnrolledSections_D.GetByIdAsync(enrolledSectionId);
        }

        //completed testing.
        public static async Task<bool> DeleteFileAsync(int enrolledSectionId)
        {
            return await cls_EnrolledSections_D.DeleteFileAsync(enrolledSectionId);
        }

        //completed testing.
        public static async Task<bool> IsFileExistAsync(string fileName)
        {
            return await cls_EnrolledSections_D.IsFileExistAsync(fileName);
        }

        //completed testing.
        public static async Task<bool> IsSectionStartedAsync(int enrolledSectionId)
        {
            return await cls_EnrolledSections_D.IsSectionStartedAsync(enrolledSectionId);
        }

        //completed testing.
        public static async Task<bool> SetAsStartedAsync(int enrolledSectionId)
        {
            return await cls_EnrolledSections_D.SetAsStartedAsync(enrolledSectionId);
        }

        //completed testing.
        public static async Task<bool> SetFileAsync(int enrolledSectionId, string fileTitle, string fileURL, string fileName)
        {
            return await cls_EnrolledSections_D.SetFileAsync(enrolledSectionId, fileTitle, fileURL, fileName);
        }

        //completed testing.
        public static async Task<bool> SetFileTitleAsync(int enrolledSectionId, string title)
        {
            return await cls_EnrolledSections_D.SetFileTitleAsync(enrolledSectionId, title);
        }
    }
}
