using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Courses_Sections
{
    public class md_CourseSection
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string PlaylistURL { get; set; }
        public string PlaylistId { get; set; }
        public string? CoverURL { get; set; }
        public string? CoverName { get; set; }
        public string CourseTitle { get; set; }

        public md_CourseSection
            (
                int sectionId, string sectionName, string playlistURL, string playlistId,
                string? coverURL, string? coverName, string courseTitle
            )
        {
            SectionId = sectionId;
            SectionName = sectionName;
            PlaylistURL = playlistURL;
            PlaylistId = playlistId;
            CoverURL = coverURL;
            CoverName = coverName;
            CourseTitle = courseTitle;
        }
    }
}
