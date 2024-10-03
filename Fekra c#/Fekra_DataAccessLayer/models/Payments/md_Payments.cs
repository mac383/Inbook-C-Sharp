using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Payments
{
    public class md_Payments
    {
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string? Description { get; set; }
        public string UserName { get; set; }

        public md_Payments
            (
                int paymentId, double amount, string currency, DateTime paymentDate,
                string paymentMethod, string? description, string userName
            )
        {
            PaymentId = paymentId;
            Amount = amount;
            Currency = currency;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            Description = description;
            UserName = userName;
        }
    }
}
