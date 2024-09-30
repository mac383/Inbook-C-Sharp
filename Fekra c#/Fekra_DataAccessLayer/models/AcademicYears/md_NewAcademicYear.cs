using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.AcademicYears
{
    public class md_NewAcademicYear
    {
        public string AcademicYear { get; set; }
        public int ByAdmin { get; set; }

        public md_NewAcademicYear(string academicYear, int byAdmin)
        {
            AcademicYear = academicYear;
            ByAdmin = byAdmin;
        }
    }
}
