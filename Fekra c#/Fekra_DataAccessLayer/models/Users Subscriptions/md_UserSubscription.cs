using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users_Subscriptions
{
    public class md_UserSubscription
    {
        public int SubscriptionId { get; set; }
        public int? PaymentId { get; set; }
        public string PlanName { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }
        public double FinalPrice { get; set; }
        public DateTime SubscriptionStart { get; set; }
        public DateTime SubscriptionEnd { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        
        public md_UserSubscription
            (
                int subscriptionId, int? paymentId, string planName, double price, byte discount, double finalPrice,
                DateTime subscriptionStart, DateTime subscriptionEnd, bool isActive, int userId
            )
        {
            SubscriptionId = subscriptionId;
            PaymentId = paymentId;
            PlanName = planName;
            Price = price;
            Discount = discount;
            FinalPrice = finalPrice;
            SubscriptionStart = subscriptionStart;
            SubscriptionEnd = subscriptionEnd;
            IsActive = isActive;
            UserId = userId;
        }
    }
}
