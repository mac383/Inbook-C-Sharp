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
                request.AddHeader("Authorization", "App 0c5e5e4561c2b60333693ed5b064b867-76df6686-5feb-4887-b44d-78911874087b");
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddHeader("Accept", "application/json");

                // تفعيل إرسال البيانات على شكل Multipart Form
                request.AlwaysMultipartFormData = true;

                // إضافة المعلمات Parameters
                request.AddParameter("from", "Murtadha <murtadha_m383@hotmail.com>");
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
