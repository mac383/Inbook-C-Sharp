using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Acceptance_Rates
{
    public class md_UpdateAcceptanceRate
    {
        public int RateId { get; set; }
        public string College { get; set; }
        public double Total { get; set; }
        public double Average { get; set; }
        public string Gender { get; set; }
        public string? Description { get; set; }
        public int BranchId { get; set; }
        public int AcademicYearId { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateAcceptanceRate
            (
                int rateId, string college, double total, double average, string gender,
                string? description, int branchId, int academicYearId, int byAdmin
            )
        {
            RateId = rateId;
            College = college;
            Total = total;
            Average = average;
            Gender = gender;
            Description = description;
            BranchId = branchId;
            AcademicYearId = academicYearId;
            ByAdmin = byAdmin;
        }
    }
}
