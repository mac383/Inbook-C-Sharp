using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Fekra_BusinessLayer.Utils.Notifications
{
    public class EmailService : INotification
    {
        // completed testing.
        public async Task<string?> SendEmailVerification(string to, string messageHeader, string messageBody, string VerificationKey)
        {
            try
            {
                var options = new RestClientOptions("https://1v4gpn.api.infobip.com")
                {
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                // إعداد طلب POST
                var request = new RestRequest("/email/3/send", Method.Post);

                // إضافة الرؤوس Headers
                request.AddHeader("Authorization", "App 12bc957878eeebe42b124d87a93cec6f-42c90db7-bd24-47a8-b903-299f9a752774");
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddHeader("Accept", "application/json");

                // تفعيل إرسال البيانات على شكل Multipart Form
                request.AlwaysMultipartFormData = true;

                // إضافة المعلمات Parameters
                request.AddParameter("from", "Murtadha <inbook@usetit.io>");
                request.AddParameter("subject", messageHeader);
                request.AddParameter("to", to);
                request.AddParameter("text", messageBody);

                // إرسال الطلب والتحقق من النتيجة
                RestResponse response = await client.ExecuteAsync(request);

                // التحقق من نجاح أو فشل العملية
                if (response.IsSuccessful)
                    return VerificationKey;

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
