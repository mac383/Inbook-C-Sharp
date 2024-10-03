using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Subscription_Plans
{
    public class md_ActiveSubscriptionPlans
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }
        public double FinalPrice { get; set; }
        public byte MonthlyDuration { get; set; }
        public byte DailyDuration { get; set; }
        public string? Description { get; set; }
        public bool IsFreeTrail { get; set; }
        public string BranchName { get; set; }

        public md_ActiveSubscriptionPlans
            (
                int planId, string planName, double price, byte discount, double finalPrice, byte monthlyDuration,
                byte dailyDuration, string? description, bool isFreeTrail, string branchName
            )
        {
            PlanId = planId;
            PlanName = planName;
            Price = price;
            Discount = discount;
            FinalPrice = finalPrice;
            MonthlyDuration = monthlyDuration;
            DailyDuration = dailyDuration;
            Description = description;
            IsFreeTrail = isFreeTrail;
            BranchName = branchName;
        }
    }
}
