using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models;
using Fekra_DataAccessLayer.models.General_Questions;
using Fekra_DataAccessLayer.models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_GeneralQuestions
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewGeneralQuestion question)
        {
            if (!Validation.CheckLength(1, 500, question.Question))
                return false;

            if (string.IsNullOrEmpty(question.Answer))
                return false;

            if (question.ByAdmin <= 0)
                return false;

            return true;
        }

        public static bool ValidateObj_UpdateMode(md_UpdateGeneralQuestion question)
        {
            if (question.QuestionId <= 0)
                return false;

            if (!Validation.CheckLength(1, 500, question.Question))
                return false;

            if (string.IsNullOrEmpty(question.Answer))
                return false;

            if (question.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_GeneralQuestions>?> GetAllAsync()
        {
            return await cls_GeneralQuestions_D.GetAllAsync();
        }

        // completed testing.
        public static async Task<md_GeneralQuestions?> GetByIdAsync(int questionId)
        {
            return await cls_GeneralQuestions_D.GetByIdAsync(questionId);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewGeneralQuestion question)
        {
            if (!ValidateObj_NewMode(question))
                return -1;

            return await cls_GeneralQuestions_D.NewAsync(question);
        }

        // completed testing.
        public static async Task<int> UpdateAsync(md_UpdateGeneralQuestion question)
        {
            if (!ValidateObj_UpdateMode(question))
                return -1;

            return await cls_GeneralQuestions_D.UpdateAsync(question);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int questionId, int byAdmin)
        {
            return await cls_GeneralQuestions_D.DeleteAsync(questionId, byAdmin);
        }
    }
}
