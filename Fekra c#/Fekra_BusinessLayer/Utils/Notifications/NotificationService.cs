using Amazon.SimpleEmail.Model;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;

namespace Fekra_BusinessLayer.Utils.Notifications
{
    public class NotificationService
    {
        public enum EN_MessageType { RegistrationConfirmation, PasswordResetConfirmation, EmailVerification, NewUserNotification }

        public static async Task<string?> SendEmailByInfibip(string to, string username, EN_MessageType messageType)
        {
            try
            {
                string verificationCode = "";
                if (messageType != EN_MessageType.NewUserNotification)
                {
                    verificationCode = KeyProvider.GetKey(6, 1, KeyProvider.EN_KeyType.Numbers);
                    if (string.IsNullOrEmpty(verificationCode))
                        return null;
                }

                string messageHeader = "";
                string greeting = "";
                string message = "";
                string messageBody = "";

                // إعداد الرسالة بناءً على نوع الرسالة
                switch (messageType)
                {
                    case EN_MessageType.RegistrationConfirmation:
                        messageHeader = "تأكيد التسجيل";
                        greeting = $"مرحبًا {username}!";
                        message = $"شكرًا لتسجيلك في منصتنا. نحن سعداء بانضمامك إلينا! لتأكيد بريدك الإلكتروني وتفعيل حسابك، يرجى استخدام كود التفعيل التالي:";
                        messageBody = GetEmailBodyHtml(messageHeader, greeting, message, verificationCode);
                        break;

                    case EN_MessageType.PasswordResetConfirmation:
                        messageHeader = "إعادة تعيين كلمة المرور";
                        greeting = $"مرحبًا {username}!";
                        message = $"تم طلب إعادة تعيين كلمة المرور. لتأكيد العملية، يرجى استخدام كود التفعيل التالي:";
                        messageBody = GetEmailBodyHtml(messageHeader, greeting, message, verificationCode);
                        break;

                    case EN_MessageType.EmailVerification:
                        messageHeader = "تأكيد البريد الإلكتروني";
                        greeting = $"مرحبًا {username}!";
                        message = $"لتأكيد بريدك الإلكتروني، يرجى استخدام كود التفعيل التالي:";
                        messageBody = GetEmailBodyHtml(messageHeader, greeting, message, verificationCode);
                        break;

                    case EN_MessageType.NewUserNotification:
                        messageHeader = "إشعار مستخدم جديد";
                        greeting = "مرحبًا مرتضى!";
                        message = $"تم تسجيل مستخدم جديد في المنصة. اسم المستخدم: {username}. يرجى التحقق من التفاصيل في لوحة التحكم.";
                        messageBody = GetAdminNotificationEmailBody(messageHeader, greeting, message);
                        break;
                }

                var options = new RestClientOptions("https://1v4gpn.api.infobip.com")
                {
                    ThrowOnAnyError = true
                };
                var client = new RestClient(options);

                // إعداد طلب POST
                var request = new RestRequest("/email/3/send", Method.Post);
                request.AddHeader("Authorization", "App 2b58065efa119bbf58b11fd213bccaa6-4f8b1435-9822-4014-8551-0f19dc526beb");
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddHeader("Accept", "application/json");

                // تفعيل إرسال البيانات على شكل Multipart Form
                request.AlwaysMultipartFormData = true;

                // إضافة المعلمات Parameters
                request.AddParameter("from", "InBook <info@inbook.tech>");
                request.AddParameter("subject", messageHeader);
                request.AddParameter("to", to);
                request.AddParameter("html", messageBody); // إرسال الرسالة بتنسيق HTML

                // إرسال الطلب والتحقق من النتيجة
                RestResponse response = await client.ExecuteAsync(request);

                // ✅ معالجة حالة المستخدم الجديد بشكل صحيح
                if (response.IsSuccessful)
                    return messageType == EN_MessageType.NewUserNotification ? null : verificationCode;

                return null;
            }
            catch
            {
                return null;
            }
        }

        private static string GetEmailBodyHtml(string messageHeader, string greeting, string message, string verificationCode)
        {
            return $@"
<html>
    <head>
        <style>
            body {{
                font-family: 'Arial', sans-serif;
                color: #333333;
                background-color: #f7f8fc;
                padding: 20px;
                margin: 0;
                direction: rtl;
                text-align: right;
            }}
            .email-container {{
                background-color: #ffffff;
                border-radius: 10px;
                padding: 40px;
                box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
                width: 600px;
                margin: 0 auto;
                direction: rtl;
            }}
            h1 {{
                color: #ffffff;
                background-color: #4154f1;
                font-size: 24px;
                font-weight: 600;
                direction: rtl;
                padding: 10px;
                border-radius: 7px;
                margin: 10px auto;
                text-align: center;
            }}
            .platform-name {{
                color: #4154f1;
                font-size: 30px;
                font-weight: bold;
                margin-bottom: 20px;
                direction: rtl;
            }}
            p {{
                font-size: 16px;
                line-height: 1.6;
                color: #555555;
                margin-bottom: 15px;
                direction: rtl;
            }}
            .verification-code {{
                width: fit-content;
                font-size: 18px;
                font-weight: bold;
                color: #ffffff;
                background-color: #4154f1;
                padding: 15px;
                border-radius: 8px;
                text-align: center;
                margin: 20px 0;
                direction: rtl;
            }}
            .footer {{
                font-size: 12px;
                color: #999999;
                margin-top: 30px;
                text-align: center;
                direction: rtl;
            }}
            .message-container {{
                margin-bottom: 25px;
                direction: rtl;
            }}
            .greeting {{
                font-size: 18px;
                color: #333333;
                direction: rtl;
            }}
        </style>
    </head>
    <body>
        <div class='email-container'>
            <div class='platform-name'>
                inBook
            </div>
            <h1>{messageHeader}</h1>
            <p class='greeting'>{greeting}</p>
            <div class='message-container'>
                <p>{message}</p>
                <div class='verification-code'>
                    <strong>{verificationCode}</strong>
                </div>
            </div>
            <div class='footer'>
                <p>إذا لم تطلب هذا البريد، يمكنك تجاهل هذه الرسالة.</p>
                <p>&copy; 2025 inBook. كل الحقوق محفوظة.</p>
            </div>
        </div>
    </body>
</html>";
        }

        private static string GetAdminNotificationEmailBody(string messageHeader, string greeting, string message)
        {
            return $@"
<html>
    <head>
        <style>
            body {{
                font-family: 'Arial', sans-serif;
                color: #333333;
                background-color: #f7f8fc;
                padding: 20px;
                margin: 0;
                direction: rtl;
                text-align: right;
            }}
            .email-container {{
                background-color: #ffffff;
                border-radius: 10px;
                padding: 40px;
                box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
                width: 600px;
                margin: 0 auto;
                direction: rtl;
            }}
            h1 {{
                color: #ffffff;
                background-color: #4154f1;
                font-size: 24px;
                font-weight: 600;
                direction: rtl;
                padding: 10px;
                border-radius: 7px;
                margin: 10px auto;
                text-align: center;
            }}
            .platform-name {{
                color: #4154f1;
                font-size: 30px;
                font-weight: bold;
                margin-bottom: 20px;
                direction: rtl;
            }}
            p {{
                font-size: 16px;
                line-height: 1.6;
                color: #555555;
                margin-bottom: 15px;
                direction: rtl;
            }}
            .footer {{
                font-size: 12px;
                color: #999999;
                margin-top: 30px;
                text-align: center;
                direction: rtl;
            }}
            .message-container {{
                margin-bottom: 25px;
                direction: rtl;
            }}
            .greeting {{
                font-size: 18px;
                color: #333333;
                direction: rtl;
            }}
        </style>
    </head>
    <body>
        <div class='email-container'>
            <div class='platform-name'>
                inBook
            </div>
            <h1>{messageHeader}</h1>
            <p class='greeting'>{greeting}</p>
            <div class='message-container'>
                <p>{message}</p>
            </div>
            <div class='footer'>
                <p>إذا كنت تعلم بذلك، يمكنك تجاهل هذه الرسالة.</p>
                <p>&copy; 2025 inBook. كل الحقوق محفوظة.</p>
            </div>
        </div>
    </body>
</html>";
        }

    }
}
