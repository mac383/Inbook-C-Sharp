using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Typical_Questions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_TypicalQuestions
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewTypicalQuestion question)
        {
            if (!Validation.CheckLength(1, 150, question.QuestionTitle))
                return false;

            if (string.IsNullOrEmpty(question.FileURL))
                return false;

            if (!Validation.CheckLength(1, 150, question.FileName))
                return false;


            if (question.QuestionTypeId <= 0)
                return false;

            if (question.MaterialId <= 0)
                return false;

            if (question.BranchId <= 0)
                return false;

            if (question.AcademicYearId <= 0)
                return false;

            if (question.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateTypicalQuestion question)
        {
            if (question.QuestionId <= 0)
                return false;

            if (!Validation.CheckLength(1, 150, question.QuestionTitle))
                return false;

            if (string.IsNullOrEmpty(question.FileURL))
                return false;


            if (!Validation.CheckLength(1, 150, question.FileName))
                return false;

            if (question.QuestionTypeId <= 0)
                return false;

            if (question.MaterialId <= 0)
                return false;

            if (question.BranchId <= 0)
                return false;

            if (question.AcademicYearId <= 0)
                return false;

            if (question.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<int> GetTypicalQuestionsPagesCountMaterialsAsync(int materialId)
        {
            return await cls_TypicalQuestions_D.GetTypicalQuestionsPagesCountMaterialsAsync(materialId);
        }

        // completed testing.
        public static async Task<md_TypicalQuestion?> GetByIdAsync(int questionId)
        {
            return await cls_TypicalQuestions_D.GetByIdAsync(questionId);
        }

        // completed testing.
        public static async Task<List<md_TypicalQuestion>?> GetByMaterialAsync(int materialId, int packageNumber)
        {
            return await cls_TypicalQuestions_D.GetByMaterialAsync(materialId, packageNumber);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int questionId, int byAdmin)
        {
            return await cls_TypicalQuestions_D.DeleteAsync(questionId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsFileExistAsync(string fileName)
        {
            return await cls_TypicalQuestions_D.IsFileExistAsync(fileName);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewTypicalQuestion question)
        {
            if (!ValidateObj_NewMode(question))
                return -1;

            return await cls_TypicalQuestions_D.NewAsync(question);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateTypicalQuestion question)
        {
            if (!ValidateObj_UpdateMode(question))
                return false;

            return await cls_TypicalQuestions_D.UpdateAsync(question);
        }
    }
}
