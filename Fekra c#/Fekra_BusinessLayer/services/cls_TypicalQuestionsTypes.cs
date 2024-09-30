using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Typical_Questions_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_TypicalQuestionsTypes
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewTypicalQuestionType type)
        {
            if (!Validation.CheckLength(1, 25, type.Type))
                return false;

            if (type.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateTypicalQuestionType type)
        {
            if (type.TypeId <= 0)
                return false;

            if (!Validation.CheckLength(1, 25, type.Type))
                return false;

            if (type.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_TypicalQuestionsTypes>?> GetAllAsync()
        {
            return await cls_TypicalQuestionsTypes_D.GetAllAsync();
        }

        // completed testing.
        public static async Task<md_TypicalQuestionsTypes?> GetByIdAsync(int typeId)
        {
            return await cls_TypicalQuestionsTypes_D.GetByIdAsync(typeId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int typeId, int byAdmin)
        {
            return await cls_TypicalQuestionsTypes_D.DeleteAsync(typeId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsHasRelationsAsync(int typeId)
        {
            return await cls_TypicalQuestionsTypes_D.IsHasRelationsAsync(typeId);
        }

        // completed testing.
        public static async Task<bool> IsExistAsync(string type)
        {
            return await cls_TypicalQuestionsTypes_D.IsExistAsync(type);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewTypicalQuestionType type)
        {
            if (!ValidateObj_NewMode(type))
                return -1;

            return await cls_TypicalQuestionsTypes_D.NewAsync(type);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateTypicalQuestionType type)
        {
            if (!ValidateObj_UpdateMode(type))
                return false;

            return await cls_TypicalQuestionsTypes_D.UpdateAsync(type);
        }
    }
}
