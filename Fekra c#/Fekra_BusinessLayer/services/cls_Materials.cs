using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Materials
    {

        // completed testing.
        public static bool ValidateObj_NewMode(md_NewMaterial material)
        {
            if (!Validation.CheckLength(1, 100, material.MaterialName))
                return false;

            if (material.BranchId <= 0)
                return false;

            if (material.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateMaterial material)
        {
            if (material.MaterialId <= 0)
                return false;

            if (!Validation.CheckLength(1, 100, material.MaterialName))
                return false;

            if (material.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_MaterialsWhereHaveTypicalQuestions>?> GetMaterialsWhereHaveTypicalQuestionsByBranchAsync(int branchId)
        {
            return await cls_Materials_D.GetMaterialsWhereHaveTypicalQuestionsByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<List<md_Materials>?> GetAllAsync()
        {
            return await cls_Materials_D.GetAllAsync();
        }

        // completed testing.
        public static async Task<List<md_Materials>?> GetByBranchAsync(int branchId)
        {
            return await cls_Materials_D.GetByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<md_Materials?> GetByIdAsync(int materialId)
        {
            return await cls_Materials_D.GetByIdAsync(materialId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int materialId, int byAdmin)
        {
            return await cls_Materials_D.DeleteAsync(materialId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsHasRelationsAsync(int materialId)
        {
            return await cls_Materials_D.IsHasRelationsAsync(materialId);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewMaterial material)
        {
            if (!ValidateObj_NewMode(material))
                return -1;

            return await cls_Materials_D.NewAsync(material);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateMaterial material)
        {
            if (!ValidateObj_UpdateMode(material))
                return false;

            return await cls_Materials_D.UpdateAsync(material);
        }
    }
}
