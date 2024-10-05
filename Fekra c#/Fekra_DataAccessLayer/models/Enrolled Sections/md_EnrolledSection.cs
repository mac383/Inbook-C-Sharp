using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Enrolled_Sections
{
    public class md_EnrolledSection
    {
        public int EnrolledSectionId { get; set; }
        public bool IsCompleted { get; set; }
        public byte CompletionRate { get; set; }
        public string? FileTitle { get; set; }
        public string? FileURL { get; set; }
        public string? FileName { get; set; }
        public string SectionName { get; set; }
        public string PlaylistURL { get; set; }
        public string? CoverURL { get; set; }
        public int LessonsCount { get; set; }

        public md_EnrolledSection
            (
                int enrolledSectionId, bool isCompleted, byte completionRate, string? fileTitle, string? fileURL,
                string? fileName, string sectionName, string playlistURL, string? coverURL, int lessonsCount
            )
        {
            EnrolledSectionId = enrolledSectionId;
            IsCompleted = isCompleted;
            CompletionRate = completionRate;
            FileTitle = fileTitle;
            FileURL = fileURL;
            FileName = fileName;
            SectionName = sectionName;
            PlaylistURL = playlistURL;
            CoverURL = coverURL;
            LessonsCount = lessonsCount;
        }
    }
}
