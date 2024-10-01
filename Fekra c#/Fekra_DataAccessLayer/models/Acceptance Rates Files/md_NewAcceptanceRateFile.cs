using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Acceptance_Rates_Files
{
    public class md_NewAcceptanceRateFile
    {
        public string FileTitle { get; set; }
        public string FileURL { get; set; }
        public string FileName { get; set; }
        public int AcademicYearId { get; set; }
        public int ByAdmin { get; set; }

        public md_NewAcceptanceRateFile
            (
                string fileTitle, string fileURL, string fileName, int academicYearId, int byAdmin
            )
        {
            FileTitle = fileTitle;
            FileURL = fileURL;
            FileName = fileName;
            AcademicYearId = academicYearId;
            ByAdmin = byAdmin;
        }
    }
}
