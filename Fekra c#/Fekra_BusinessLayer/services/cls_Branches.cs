using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Branches
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewBranch branch)
        {
            if (!Validation.CheckLength(1, 50, branch.BranchName))
                return false;

            if (branch.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateBranch branch)
        {
            if (branch.BranchId <= 0)
                return false;

            if (!Validation.CheckLength(1, 50, branch.BranchName))
                return false;

            if (branch.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_Branches>?> GetAllAsync()
        {
            return await cls_Branches_D.GetAllAsync();
        }

        // completed testing.
        public static async Task<md_Branches?> GetByIdAsync(int branchId)
        {
            return await cls_Branches_D.GetByIdAsync(branchId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int branchId, int byAdmin)
        {
            return await cls_Branches_D.DeleteAsync(branchId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsBranchExistAsync(string branchName)
        {
            return await cls_Branches_D.IsBranchExistAsync(branchName);
        }

        // completed testing.
        public static async Task<bool> IsHasRelationsAsync(int branchId)
        {
            return await cls_Branches_D.IsHasRelationsAsync(branchId);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewBranch branch)
        {
            if (!ValidateObj_NewMode(branch))
                return -1;

            return await cls_Branches_D.NewAsync(branch);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateBranch branch)
        {
            if (!ValidateObj_UpdateMode(branch))
                return false;

            return await cls_Branches_D.UpdateAsync(branch);
        }
    }
}
