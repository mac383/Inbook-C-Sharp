using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Courses_Sections
{
    public class md_CompleteCourseSection
    {
        public string SectionName { get; set; }
        public string PlaylistURL { get; set; }
        public string PlaylistId { get; set; }
        public int CourseId { get; set; }
        public DataTable? Lessons { get; set; }
        public string CoverURL { get; set; }
        public string CoverName { get; set; }
        public int ByAdmin { get; set; }

        public md_CompleteCourseSection
            (
                string sectionName, string playlistURL, string playlistId, 
                int courseId, DataTable? lessons, string coverURL, string coverName, int byAdmin
            )
        {
            SectionName = sectionName;
            PlaylistURL = playlistURL;
            PlaylistId = playlistId;
            CourseId = courseId;
            Lessons = lessons;
            CoverURL = coverURL;
            CoverName = coverName;
            ByAdmin = byAdmin;
        }
    }
}
