using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Acceptance_Rates;
using Fekra_DataAccessLayer.models.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_AcceptanceRates
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewAcceptanceRate rate)
        {
            if (!Validation.CheckLength(1, 250, rate.College))
                return false;

            if (!Validation.IsFloat(rate.Total.ToString()))
                return false;

            if (!Validation.IsFloat(rate.Average.ToString()))
                return false;

            if (!Validation.CheckLength(1, 10, rate.Gender))
                return false;

            if (!string.IsNullOrEmpty(rate.Description))
                if (!Validation.CheckLength(1, 150, rate.Description))
                    return false;

            if (rate.BranchId <= 0)
                return false;

            if (rate.AcademicYearId <= 0)
                return false;

            if (rate.ByAdmin <= 0)
                return false;

            return true;
        }

        public static bool ValidateObj_UpdateMode(md_UpdateAcceptanceRate rate)
        {
            if (rate.RateId <= 0)
                return false;

            if (!Validation.CheckLength(1, 250, rate.College))
                return false;

            if (!Validation.IsFloat(rate.Total.ToString()))
                return false;

            if (!Validation.IsFloat(rate.Average.ToString()))
                return false;

            if (!Validation.CheckLength(1, 10, rate.Gender))
                return false;

            if (!string.IsNullOrEmpty(rate.Description))
                if (!Validation.CheckLength(1, 150, rate.Description))
                    return false;

            if (rate.BranchId <= 0)
                return false;

            if (rate.AcademicYearId <= 0)
                return false;

            if (rate.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_AcceptanceRates_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<int> GetCountByBranchAsync(int branchId)
        {
            return await cls_AcceptanceRates_D.GetCountByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<int> GetPagesCountByBranchAsync(int branchId)
        {
            return await cls_AcceptanceRates_D.GetPagesCountByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<List<md_AcceptanceRates>?> GetByBranchAsync(int branchId, int pageNumber)
        {
            return await cls_AcceptanceRates_D.GetByBranchAsync(branchId, pageNumber);
        }

        // completed testing.
        public static async Task<md_AcceptanceRates?> GetByIdAsync(int rateId)
        {
            return await cls_AcceptanceRates_D.GetByIdAsync(rateId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int rateId, int byAdmin)
        {
            return await cls_AcceptanceRates_D.DeleteAsync(rateId, byAdmin);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewAcceptanceRate rate)
        {
            if (!ValidateObj_NewMode(rate))
                return -1;

            return await cls_AcceptanceRates_D.NewAsync(rate);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateAcceptanceRate rate)
        {
            if (!ValidateObj_UpdateMode(rate)) 
                return false;

            return await cls_AcceptanceRates_D.UpdateAsync(rate);
        }
    }
}
