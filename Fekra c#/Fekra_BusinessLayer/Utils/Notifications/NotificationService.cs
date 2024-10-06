using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // completed testing.
        public async Task<string?> SendEmailVerification(string to, string username, EN_MessageType messageType)
        {
            string verificationCode = KeyProvider.GetKey(6, 1, KeyProvider.EN_KeyType.Numbers);

            if (string.IsNullOrEmpty(verificationCode))
                return null;

            (string messageHeader, string messageBody) = (string.Empty, string.Empty);

            switch (messageType)
            {
                case EN_MessageType.RegistrationConfirmation:
                    (messageHeader, messageBody) = RegistrationConfirmationMessage(username, verificationCode);
                    break;

                case EN_MessageType.PasswordResetConfirmation:
                    (messageHeader, messageBody) = PasswordResetConfirmationMessage(username, verificationCode);
                    break;

                case EN_MessageType.EmailVerification:
                    (messageHeader, messageBody) = EmailVerificationMessage(username, verificationCode);
                    break;
            }
            
            return await _Notification.SendEmailVerification(to, messageHeader, messageBody, verificationCode);
        }

        // completed testing.
        private (string, string) RegistrationConfirmationMessage(string username, string verificationCode)
        {
            string messageHeader = "تأكيد بريدك الإلكتروني";

            string messageBody = $@"
                ،{username} عزيزي

                ![Fekra] شكرًا لتسجيلك في
                .نحتاج إلى تأكيد بريدك الإلكتروني لضمان صحة معلوماتك
                
                .{verificationCode} :كود التحقق الخاص بك هو

                .يمكنك تجاهل هذه الرسالة في حال لم تقم بطلبها

                مع أطيب التحيات
                [فريق الدعم أو الخدمة]";

            return (messageHeader, messageBody);
        }

        // completed testing.
        private (string, string) PasswordResetConfirmationMessage(string username, string verificationCode)
        {
            string messageHeader = "إعادة تعيين كلمة المرور";

            string messageBody = $@"
                ،{username} عزيزي

                .[Fekra] لقد تم استلام طلب لإعادة تعيين كلمة المرور الخاصة بك على منصة
                
                .{verificationCode} :كود التحقق الخاص بك هو

                .يمكنك تجاهل هذه الرسالة في حال لم تقم بطلبها

                مع أطيب التحيات
                [فريق الدعم أو الخدمة]";

            return (messageHeader, messageBody);
        }

        // completed testing.
        private (string, string) EmailVerificationMessage(string username, string verificationCode)
        {
            string messageHeader = "تأكيد تغيير البريد الإلكتروني";

            string messageBody = $@"
                ،{username} عزيزي

                .[Fekra] تم طلب التحقق من البريد الإلكتروني الخاص بك لتحديث بريدك الإلكتروني على حسابك في منصة
                
                .{verificationCode} :كود التحقق الخاص بك هو

                .يمكنك تجاهل هذه الرسالة في حال لم تقم بطلبها  

                مع أطيب التحيات
                [فريق الدعم أو الخدمة]";

            return (messageHeader, messageBody);
        }
    }
}
