using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Payments
{
    public class md_NewPayment
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
        public int ByAdmin { get; set; }

        public md_NewPayment
            (
                double amount, string currency, string paymentMethod,
                string? description, int userId, int subscriptionId, int byAdmin
            )
        {
            Amount = amount;
            Currency = currency;
            PaymentMethod = paymentMethod;
            Description = description;
            UserId = userId;
            SubscriptionId = subscriptionId;
            ByAdmin = byAdmin;
        }
    }
}