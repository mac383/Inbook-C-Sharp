using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Lessons
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewLesson lesson)
        {
            if (!Validation.CheckLength(1, 250, lesson.LessonTitle))
                return false;

            if (string.IsNullOrEmpty(lesson.VideoURL)) 
                return false;

            if (lesson.SectionId <= 0)
                return false;
            
            if (lesson.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_Lessons>?> GetBySectionAsync(int sectionId)
        {
            return await cls_Lessons_D.GetBySectionAsync(sectionId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int lessonId, int byAdmin)
        {
            return await cls_Lessons_D.DeleteAsync(lessonId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> UpdateTitleAsync(int lessonId, string title, int byAdmin)
        {
            if (lessonId <= 0 || !Validation.CheckLength(1, 250, title) || byAdmin <= 0)
                return false;

            return await cls_Lessons_D.UpdateTitleAsync(lessonId, title, byAdmin);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewLesson lesson)
        {
            if (!ValidateObj_NewMode(lesson))
                return -1;

            string? videoId = cls_YoutubeDataApiService.ExtractVideoId(lesson.VideoURL);

            if (videoId == null)
                return -1;

            md_CompleteLesson completeLesson = new md_CompleteLesson
                (
                    lesson.LessonTitle,
                    lesson.VideoURL,
                    videoId,
                    lesson.SectionId,
                    lesson.ByAdmin
                );

            return await cls_Lessons_D.NewAsync(completeLesson);
        }
    }
}
