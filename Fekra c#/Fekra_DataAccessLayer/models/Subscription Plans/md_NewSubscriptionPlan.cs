using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Subscription_Plans
{
    public class md_NewSubscriptionPlan
    {
        public string PlanName { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }
        public byte MonthlyDuration { get; set; }
        public byte DailyDuration { get; set; }
        public string? Description { get; set; }
        public int BranchId { get; set; }
        public int ByAdmin { get; set; }

        public md_NewSubscriptionPlan
            (
                string planName, double price, byte discount, byte monthlyDuration, 
                byte dailyDuration, string? description, int branchId, int byAdmin
            )
        {
            PlanName = planName;
            Price = price;
            Discount = discount;
            MonthlyDuration = monthlyDuration;
            DailyDuration = dailyDuration;
            Description = description;
            BranchId = branchId;
            ByAdmin = byAdmin;
        }
    }
}
