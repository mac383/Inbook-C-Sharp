using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Enrolled_Sections
{
    public class md_EnrolledSections
    {
        public int EnrolledSectionId { get; set; }
        public bool IsCompleted { get; set; }
        public byte CompletionRate { get; set; }
        public bool IsStarted { get; set; }
        public string SectionName { get; set; }
        public string? CoverURL { get; set; }
        public int LessonsCount { get; set; }

        public md_EnrolledSections
            (
                int enrolledSectionId, bool isCompleted, byte completionRate,
                bool isStarted, string sectionName, string? coverURL, int lessonsCount
            )
        {
            EnrolledSectionId = enrolledSectionId;
            IsCompleted = isCompleted;
            CompletionRate = completionRate;
            IsStarted = isStarted;
            SectionName = sectionName;
            CoverURL = coverURL;
            LessonsCount = lessonsCount;
        }
    }
}
