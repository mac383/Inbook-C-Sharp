using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Acceptance_Rates_Files
{
    public class md_AcceptanceRatesFiles
    {
        public int FileId { get; set; }
        public string FileTitle { get; set; }
        public string FileURL { get; set; }
        public string FileName { get; set; }
        public string AcademicYear { get; set; }

        public md_AcceptanceRatesFiles
            (
                int fileId, string fileTitle, string fileURL, string fileName, string academicYear
            )
        {
            FileId = fileId;
            FileTitle = fileTitle;
            FileURL = fileURL;
            FileName = fileName;
            AcademicYear = academicYear;
        }
    }
}
