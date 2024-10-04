using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Courses_Sections
{
    public class md_NewCourseSection
    {
        public string SectionName { get; set; }
        public string PlaylistURL { get; set; }
        public int CourseId { get; set; }
        public int ByAdmin { get; set; }

        public md_NewCourseSection
            (
                string sectionName, string playlistURL, int courseId, int byAdmin
            )
        {
            SectionName = sectionName;
            PlaylistURL = playlistURL;
            CourseId = courseId;
            ByAdmin = byAdmin;
        }
    }
}
