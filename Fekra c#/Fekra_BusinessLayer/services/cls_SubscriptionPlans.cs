using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Subscription_Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_SubscriptionPlans
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewSubscriptionPlan plan)
        {
            if (!Validation.CheckLength(1, 100, plan.PlanName))
                return false;

            if (!Validation.IsFloat(plan.Price.ToString()))
                return false;

            if (plan.Discount < 0)
                return false;

            if (plan.MonthlyDuration < 0)
                return false;

            if (plan.DailyDuration < 0)
                return false;

            if (!string.IsNullOrEmpty(plan.Description))
                if (!Validation.CheckLength(1, 250, plan.Description))
                    return false;

            if (plan.BranchId <= 0)
                return false;

            if (plan.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateSubscriptionPlan plan)
        {
            if (plan.PlanId <= 0)
                return false;

            if (!Validation.CheckLength(1, 100, plan.PlanName))
                return false;

            if (!Validation.IsFloat(plan.Price.ToString()))
                return false;

            if (plan.Discount < 0)
                return false;

            if (plan.MonthlyDuration < 0)
                return false;

            if (plan.DailyDuration < 0)
                return false;

            if (plan.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_ActiveSubscriptionPlans>?> GetActivePlansByBranchAsync(int branchId)
        {
            return await cls_SubscriptionPlans_D.GetActivePlansByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<List<md_SubscriptionPlans>?> GetByBranchAsync(int branchId)
        {
            return await cls_SubscriptionPlans_D.GetByBranchAsync(branchId);
        }

        // completed testing.
        public static async Task<md_SubscriptionPlans?> GetByIdAsync(int planId)
        {
            return await cls_SubscriptionPlans_D.GetByIdAsync(planId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int planId, int byAdmin)
        {
            return await cls_SubscriptionPlans_D.DeleteAsync(planId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsHasRelationsAsync(int planId)
        {
            return await cls_SubscriptionPlans_D.IsHasRelationsAsync(planId);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewSubscriptionPlan plan)
        {
            if (!ValidateObj_NewMode(plan))
                return -1;

            return await cls_SubscriptionPlans_D.NewAsync(plan);
        }

        // completed testing.
        public static async Task<bool> SetAsActiveAsync(int planId, int byAdmin)
        {
            return await cls_SubscriptionPlans_D.SetAsActiveAsync(planId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetAsInActiveAsync(int planId, int byAdmin)
        {
            return await cls_SubscriptionPlans_D.SetAsInActiveAsync(planId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetDescriptionAsync(int planId, string description, int byAdmin)
        {
            return await cls_SubscriptionPlans_D.SetDescriptionAsync(planId, description, byAdmin);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateSubscriptionPlan plan)
        {
            if (!ValidateObj_UpdateMode(plan))
                return false;

            return await cls_SubscriptionPlans_D.UpdateAsync(plan);
        }
    }
}
