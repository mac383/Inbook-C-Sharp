using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users_Subscriptions
{
    public class md_UsersSubscriptions
    {
        public int SubscriptionId { get; set; }
        public string PlanName { get; set; }
        public string BranchName { get; set; }
        public string UserName { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }
        public double FinalPrice { get; set; }
        public DateTime SubscriptionStart { get; set; }
        public DateTime SubscriptionEnd { get; set; }

        public md_UsersSubscriptions
            (
                int subscriptionId, string planName, string branchName, string userName, double price,
                byte discount, double finalPrice, DateTime subscriptionStart, DateTime subscriptionEnd
            )
        {
            SubscriptionId = subscriptionId;
            PlanName = planName;
            BranchName = branchName;
            UserName = userName;
            Price = price;
            Discount = discount;
            FinalPrice = finalPrice;
            SubscriptionStart = subscriptionStart;
            SubscriptionEnd = subscriptionEnd;
        }
    }
}
