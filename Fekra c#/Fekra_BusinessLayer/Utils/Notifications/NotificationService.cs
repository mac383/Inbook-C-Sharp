using Amazon.SimpleEmail.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.Utils.Notifications
{
    public class NotificationService
    {
        public enum EN_MessageType { RegistrationConfirmation, PasswordResetConfirmation, EmailVerification }
        private INotification _Notification;

        public NotificationService(INotification notification)
        {
            _Notification = notification;
        }

        public async Task<string?> SendEmail(string to, string username, EN_MessageType messageType)
        {
            string verificationCode = KeyProvider.GetKey(6, 1, KeyProvider.EN_KeyType.Numbers);

            if (string.IsNullOrEmpty(verificationCode))
                return null;

            string messageHeader = "";
            string messageBody = "";
            string greeting = "";
            string message = "";
            string additionalMessage = "";

            switch (messageType)
            {
                case EN_MessageType.RegistrationConfirmation:
                    messageHeader = "تأكيد التسجيل";
                    greeting = $"مرحبًا {username}!";
                    message = $"شكرًا لتسجيلك في منصتنا. نحن سعداء بانضمامك إلينا! لتأكيد بريدك الإلكتروني وتفعيل حسابك، يرجى استخدام كود التفعيل التالي:";
                    additionalMessage = "إذا لم تقم بتسجيل هذا الحساب، يمكنك تجاهل هذه الرسالة.";
                    break;

                case EN_MessageType.PasswordResetConfirmation:
                    messageHeader = "إعادة تعيين كلمة المرور";
                    greeting = $"مرحبًا {username}!";
                    message = $"تم طلب إعادة تعيين كلمة المرور. لتأكيد العملية، يرجى استخدام كود التفعيل التالي:";
                    additionalMessage = "إذا لم تقم بطلب إعادة تعيين كلمة المرور، يمكنك تجاهل هذه الرسالة.";
                    break;

                case EN_MessageType.EmailVerification:
                    messageHeader = "تأكيد البريد الإلكتروني";
                    greeting = $"مرحبًا {username}!";
                    message = $"لتأكيد بريدك الإلكتروني، يرجى استخدام كود التفعيل التالي:";
                    additionalMessage = "إذا لم تقم بتسجيل هذا الحساب، يمكنك تجاهل هذه الرسالة.";
                    break;
            }

            messageBody = GetEmailTemplate();
            messageBody = messageBody.Replace("{greeting}", greeting)
                   .Replace("{message}", message)
                   .Replace("{verificationCode}", verificationCode)
                   .Replace("{additionalMessage}", additionalMessage)
                   .Replace("{emailSubject}", messageHeader);

            return await _Notification.SendEmailVerification(to, messageHeader, messageBody, verificationCode);
        }

        private string GetEmailTemplate()
        {
            string template = @"
<!DOCTYPE html>
<html lang='ar'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>inBook</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: right; /* جعل النص من اليمين لليسار */
            direction: rtl;  /* جعل اتجاه النص RTL */
            background-color: #f4f4f4;
            padding: 20px;
        }
        .container {
            max-width: 700px;
            width: 90%;
            margin: auto;
            background: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            direction: rtl;
        }
        h2 {
            color: #333;
            direction: rtl;
        }
        .message {
            font-size: 16px;
        }
        .verification-code {
            direction: rtl;
            background: #4154f1; /* اللون الأساسي */
            color: white;
            display: inline-block;
            padding: 10px 20px;
            border-radius: 5px;
            font-size: 18px;
            font-weight: bold;
        }
        .footer {
            direction: rtl;
            color: #777;
            font-size: 14px;
        }
        .footer a {
            direction: rtl;
            color: #4154f1; /* اللون الأساسي */
            text-decoration: none;
        }
        .header {
            padding: 10px;
            border-radius: 10px;
            background: #4154f1;
            color: white;
            direction: ltr;
        }
        .header h1 {
            width: 100%;
            text-align: center;
            margin: 0;
            font-size: 36px;
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>inBook</h1>
        </div>
        <h2>{greeting}</h2>
        <p class='message'>{message}</p>
        <h3 class='verification-code'>{verificationCode}</h3>
        <p>{additionalMessage}</p>
        <p class='footer'>
            إذا كنت بحاجة إلى مساعدة، يمكنك التواصل مع فريق الدعم عبر
            <a href='mailto:support@inbook.tech'>support@inbook.tech</a>.<br>
            مع أطيب التحيات
        </p>
    </div>
</body>
</html>";
            return template;
        }
    }
}
