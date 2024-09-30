using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.AcademicYears
{
    public class md_UpdateAcademicYear
    {
        public int AcademicYearId { get; set; }
        public string AcademicYear { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateAcademicYear(int academicYearId, string academicYear, int byAdmin)
        {
            AcademicYearId = academicYearId;
            AcademicYear = academicYear;
            ByAdmin = byAdmin;
        }
    }
}
