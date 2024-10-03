using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Subscription_Plans
{
    public class md_UpdateSubscriptionPlan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }
        public byte MonthlyDuration { get; set; }
        public byte DailyDuration { get; set; }
        public int ByAdmin { get; set; }

        public md_UpdateSubscriptionPlan
            (
                int planId, string planName, double price, byte discount, byte monthlyDuration,
                byte dailyDuration, int byAdmin
            )
        {
            PlanId = planId;
            PlanName = planName;
            Price = price;
            Discount = discount;
            MonthlyDuration = monthlyDuration;
            DailyDuration = dailyDuration;
            ByAdmin = byAdmin;
        }
    }
}
