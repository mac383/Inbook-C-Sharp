using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Courses_Sections
{
    public class md_CoursesSections
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string? CoverURL { get; set; }
        public string? CoverName { get; set; }
        public int LessonsCount { get; set; }

        public md_CoursesSections
            (
                int sectionId, string sectionName, string? coverURL, string? coverName, int lessonsCount
            )
        {
            SectionId = sectionId;
            SectionName = sectionName;
            CoverURL = coverURL;
            CoverName = coverName;
            LessonsCount = lessonsCount;
        }
    }
}
