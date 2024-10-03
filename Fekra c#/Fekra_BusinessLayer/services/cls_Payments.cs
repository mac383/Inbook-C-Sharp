using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Payments
    {
        public static bool ValidateObj_NewMode(md_NewPayment payment)
        {
            if (!Validation.IsFloat(payment.Amount.ToString()) || payment.Amount < 0)
                return false;

            if (!Validation.CheckLength(1, 50, payment.Currency))
                return false;

            if (!Validation.CheckLength(1, 100, payment.PaymentMethod))
                return false;

            if (!string.IsNullOrEmpty(payment.Description))
                if (!Validation.CheckLength(1, 250, payment.Description))
                    return false;

            if (payment.UserId <= 0)
                return false;

            if (payment.SubscriptionId <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<double> GetTotalPaymentsAsync()
        {
            return await cls_Payments_D.GetTotalPaymentsAsync();
        }

        // completed testing.
        public static async Task<int> GetPaymentsPagesCountAllAsync()
        {
            return await cls_Payments_D.GetPaymentsPagesCountAllAsync();
        }

        // completed testing.
        public static async Task<List<md_Payments>?> GetAllAsync()
        {
            return await cls_Payments_D.GetAllAsync();
        }

        // completed testing.
        public static async Task<List<md_Payments>?> GetByUserAsync(int userId)
        {
            return await cls_Payments_D.GetByUserAsync(userId);
        }

        // completed testing.
        public static async Task<md_Payments?> GetByIdAsync(int paymentId)
        {
            return await cls_Payments_D.GetByIdAsync(paymentId);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewPayment payment)
        {
            if (!ValidateObj_NewMode(payment))
                return -1;

            return await cls_Payments_D.NewAsync(payment);
        }
    }
}
