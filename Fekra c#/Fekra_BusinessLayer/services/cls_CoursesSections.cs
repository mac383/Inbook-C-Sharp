using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Courses_Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Data;
using Microsoft.VisualBasic;
using Fekra_BusinessLayer.Utils;

namespace Fekra_BusinessLayer.services
{
    public class cls_CoursesSections
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewCourseSection section)
        {
            if (!Validation.CheckLength(1, 250, section.SectionName))
                return false;

            if (string.IsNullOrEmpty(section.PlaylistURL))
                return false;

            if (section.CourseId <= 0)
                return false;

            if (section.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_CoursesSections>?> GetSectionsByCourseAsync(int courseId)
        {
            return await cls_CoursesSections_D.GetSectionsByCourseAsync(courseId);
        }

        // completed testing.
        public static async Task<md_CourseSection?> GetByIdAsync(int sectionId)
        {
            return await cls_CoursesSections_D.GetByIdAsync(sectionId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int sectionId, int byAdmin)
        {
            return await cls_CoursesSections_D.DeleteAsync(sectionId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> DeleteCoverAsync(int sectionId, int byAdmin)
        {
            return await cls_CoursesSections_D.DeleteCoverAsync(sectionId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsHasRelationsAsync(int sectionId)
        {
            return await cls_CoursesSections_D.IsHasRelationsAsync(sectionId);
        }

        // completed testing.
        public static async Task<bool> IsCoverExistAsync(string coverName)
        {
            return await cls_CoursesSections_D.IsCoverExistAsync(coverName);
        }

        // completed testing.
        public static async Task<bool> SetCoverAsync(int sectionId, string imageURL, string imageName, int byAdmin)
        {
            return await cls_CoursesSections_D.SetCoverAsync(sectionId, imageURL, imageName, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetSectionNameAsync(int sectionId, string sectionName, int byAdmin)
        {
            return await cls_CoursesSections_D.SetSectionNameAsync(sectionId, sectionName, byAdmin);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewCourseSection newSection)
        {
            if (!ValidateObj_NewMode(newSection))
                return -1;

            string? playlistId = cls_YoutubeDataApiService.ExtractPlaylistId(newSection.PlaylistURL);

            if (playlistId == null)
                return -1;

            DataTable? lessons = await cls_YoutubeDataApiService.GetPlaylistVideos(newSection.PlaylistURL);

            string? coverURL = await cls_YoutubeDataApiService.GetPlaylistThumbnail(playlistId);

            if (string.IsNullOrEmpty(coverURL))
                return -1;

            string coverName;

            do
            {
                coverName = KeyProvider.GetKey(6, 2, KeyProvider.EN_KeyType.NumbersLetters);
            } while (await IsCoverExistAsync(coverName));

            md_CompleteCourseSection section = new md_CompleteCourseSection
                (
                    newSection.SectionName,
                    newSection.PlaylistURL,
                    playlistId,
                    newSection.CourseId,
                    lessons,
                    coverURL,
                    coverName,
                    newSection.ByAdmin
                );

            return await cls_CoursesSections_D.NewAsync(section);
        }
    }
}
