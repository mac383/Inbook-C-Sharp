using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Acceptance_Rates
{
    public class md_AcceptanceRates
    {
        public int RateId { get; set; }
        public string College { get; set; }
        public double Total { get; set; }
        public double Average { get; set; }
        public string Gender { get; set; }
        public string? Description { get; set; }
        public string BranchName { get; set; }
        public string AcademicYear { get; set; }

        public md_AcceptanceRates
            (
                int rateId, string college, double total, double average, 
                string gender, string? description, string branchName, string academicYear
            )
        {
            RateId = rateId;
            College = college;
            Total = total;
            Average = average;
            Gender = gender;
            Description = description;
            BranchName = branchName;
            AcademicYear = academicYear;
        }
    }
}
