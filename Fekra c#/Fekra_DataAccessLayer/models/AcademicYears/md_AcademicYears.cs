using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.AcademicYears
{
    public class md_AcademicYears
    {
        public int YearId { get; set; }
        public string AcademicYear { get; set; }

        public md_AcademicYears(int yearId, string academicYear)
        {
            YearId = yearId;
            AcademicYear = academicYear;
        }
    }
}
