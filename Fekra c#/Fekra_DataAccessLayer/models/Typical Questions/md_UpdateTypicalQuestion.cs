using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Typical_Questions
{
    public class md_UpdateTypicalQuestion
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string FileURL { get; set; }
        public string FileName { get; set; }
        public int QuestionTypeId { get; set; }
        public int MaterialId { get; set; }
        public int BranchId { get; set; }
        public int AcademicYearId { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateTypicalQuestion
            (
                int questionId, string questionTitle, string fileURL, string fileName, int questionTypeId,
                int materialId, int branchId, int academicYearId, int byAdmin
            )
        {
            QuestionId = questionId;
            QuestionTitle = questionTitle;
            FileURL = fileURL;
            FileName = fileName;
            QuestionTypeId = questionTypeId;
            MaterialId = materialId;
            BranchId = branchId;
            AcademicYearId = academicYearId;
            ByAdmin = byAdmin;
        }
    }
}
