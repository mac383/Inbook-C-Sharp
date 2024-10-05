using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.Utils.Notifications
{
    public class NotificationService
    {
        private INotification _Notification;

        public NotificationService(INotification notification)
        {
            _Notification = notification;
        }

        // completed testing.
        public async Task<string?> SendEmailVerification(string to, string username)
        {
            string virificationKey = KeyProvider.GetKey(6, 1, KeyProvider.EN_KeyType.Numbers);

            if (string.IsNullOrEmpty(virificationKey))
                return null;

            string messageHeader = "تأكيد بريدك الإلكتروني";

            string messageBody = $@"
                عزيزي {username}،

                شكرًا لتسجيلك في [Fekra]!
                نحتاج إلى تأكيد بريدك الإلكتروني لضمان صحة معلوماتك.
                
                كود التحقق الخاص بك هو: {virificationKey}.

                إذا لم تقم بالتسجيل في [Fekra]، يمكنك تجاهل هذه الرسالة.

                مع أطيب التحيات،
                [فريق الدعم أو الخدمة]";

            return await _Notification.SendEmailVerification(to, messageHeader, messageBody, virificationKey);
        }
    }
}
