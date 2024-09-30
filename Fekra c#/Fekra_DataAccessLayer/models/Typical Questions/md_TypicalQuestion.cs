using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Typical_Questions
{
    public class md_TypicalQuestion
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string FileURL { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string MaterialName { get; set; }
        public string BranchName { get; set; }
        public string AcademicYear { get; set; }

        public md_TypicalQuestion
            (
                int questionId, string questionTitle, string fileURL, string fileName,
                string type, string materialName, string branchName, string academicYear
            )
        {
            QuestionId = questionId;
            QuestionTitle = questionTitle;
            FileURL = fileURL;
            FileName = fileName;
            Type = type;
            MaterialName = materialName;
            BranchName = branchName;
            AcademicYear = academicYear;
        }
    }
}
