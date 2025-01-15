using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Enrolled_Sections
{
    public class md_newFile(int enrolledSectionId, string fileTitle, string fileURL, string fileName)
    {
        public int EnrolledSectionId { get; set; } = enrolledSectionId;
        public string FileTitle { get; set; } = fileTitle;
        public string FileURL { get; set; } = fileURL;
        public string FileName { get; set; } = fileName;
    }
}
