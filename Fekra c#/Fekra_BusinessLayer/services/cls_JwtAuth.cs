using Fekra_BusinessLayer.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_JwtAuth
    {

        private readonly string _issuer = "inbook-backend-authentication-key-2025@#%$*&!(xyzINBOOK12345)";
        private readonly string _audience = "inbook-users-platform-secure-2025$%#@!^&*(abcDEF67890)";
        private readonly string _secretKey = "(InBook2o25*SmartAI@EduPlatform)"; // استخدم سر قوي للتشفير
        private readonly TimeSpan _accessTokenExpiration = TimeSpan.FromHours(1);  // صلاحية Access Token
        private readonly TimeSpan _refreshTokenExpiration = TimeSpan.FromDays(1);  // صلاحية Refresh Token

        private string GenerateSignature(string payload)
        {
            // دمج الـ payload مع الـ secretKey
            string dataToSign = payload + _secretKey;
            return Encryption.HashEncrypt(dataToSign); // استخدام دالة HashEncrypt للتوقيع
        }

        public string GenerateAccessToken(string userId)
        {
            // جمع البيانات
            var expirationTime = DateTime.UtcNow.Add(_accessTokenExpiration);
            var payload = new
            {
                userId = userId,
                exp = expirationTime.ToString("yyyy-MM-dd HH:mm:ss"),
                iss = _issuer,
                aud = _audience,
                type = "access-token"
            };

            // تحويل البيانات إلى JSON string
            string payloadJson = JsonConvert.SerializeObject(payload);

            // توليد التوقيع باستخدام دالة HashEncrypt
            string signature = GenerateSignature(payloadJson);

            // بناء التوكن النهائي
            string token = $"{payloadJson}.{signature}";

            // تشفير التوكن باستخدام الدالة SymmetricEncrypt
            string encryptedToken = Encryption.SymmetricEncrypt(token);

            return encryptedToken;
        }

        public bool ValidateAccessToken(string encryptedToken)
        {
            // فك تشفير التوكن
            string token = Encryption.SymmetricDecrypt(encryptedToken);

            // تقسيم التوكن إلى جزئين (payload و signature)
            var tokenParts = token.Split('.');

            if (tokenParts.Length != 2)
            {
                return false; // التوكن غير صالح (ليس لديه جزئين)
            }

            // استخراج الـ payload و الـ signature من التوكن
            string payloadJson = tokenParts[0];
            string signature = tokenParts[1];

            // إعادة إنشاء التوقيع باستخدام الـ payload و الـ secretKey للتحقق منه
            string expectedSignature = GenerateSignature(payloadJson);

            // التحقق من التوقيع
            if (signature != expectedSignature)
            {
                return false; // التوقيع غير صحيح
            }

            // تحويل الـ payload إلى كائن لقراءته بسهولة
            var payload = JsonConvert.DeserializeObject<dynamic>(payloadJson);

            // التحقق من userId
            if (Convert.ToInt32(payload.userId) <= 0)
            {
                return false; // userId غير صالح
            }

            // التحقق من الـ issuer و الـ audience
            if (payload.iss != _issuer || payload.aud != _audience)
            {
                return false; // الـ issuer أو الـ audience غير صحيحين
            }

            // التحقق من تاريخ الانتهاء (exp)
            DateTime expirationDate;
            if (!DateTime.TryParse(payload.exp.ToString(), out expirationDate))
            {
                return false; // تاريخ الانتهاء غير صالح
            }

            if (expirationDate <= DateTime.UtcNow)
            {
                return false; // التوكن انتهت صلاحيته
            }

            if (payload.type != "access-token")
            {
                return false;
            }

            return true; // التوكن صالح
        }

        public string GenerateRefreshToken(string userId)
        {
            DateTime expirationTime = DateTime.UtcNow.Add(_refreshTokenExpiration);

            // جمع البيانات
            var payload = new
            {
                userId = userId,
                exp = expirationTime.ToString("yyyy-MM-dd HH:mm:ss"),
                iss = _issuer,
                aud = _audience,
                type = "refresh-token"
            };

            // تحويل البيانات إلى JSON string
            string payloadJson = JsonConvert.SerializeObject(payload);

            // توليد التوقيع باستخدام دالة HashEncrypt
            string signature = GenerateSignature(payloadJson);

            // بناء التوكن النهائي
            string refreshToken = $"{payloadJson}.{signature}";

            // تشفير التوكن بالكامل باستخدام التشفير المتماثل (AES)
            string encryptedRefreshToken = Encryption.SymmetricEncrypt(refreshToken); // تشفير الـ Refresh Token

            return encryptedRefreshToken;
        }

        public bool ValidateRefreshToken(string encryptedToken)
        {
            // فك تشفير التوكن
            string token = Encryption.SymmetricDecrypt(encryptedToken);

            // تقسيم التوكن إلى جزئين (payload و signature)
            var tokenParts = token.Split('.');

            if (tokenParts.Length != 2)
            {
                return false; // التوكن غير صالح (ليس لديه جزئين)
            }

            // استخراج الـ payload و الـ signature من التوكن
            string payloadJson = tokenParts[0];
            string signature = tokenParts[1];

            // إعادة إنشاء التوقيع باستخدام الـ payload و الـ secretKey للتحقق منه
            string expectedSignature = GenerateSignature(payloadJson);

            // التحقق من التوقيع
            if (signature != expectedSignature)
            {
                return false; // التوقيع غير صحيح
            }

            // تحويل الـ payload إلى كائن لقراءته بسهولة
            var payload = JsonConvert.DeserializeObject<dynamic>(payloadJson);

            // التحقق من userId
            if (Convert.ToInt32(payload.userId) <= 0)
            {
                return false; // userId غير صالح
            }

            // التحقق من الـ issuer و الـ audience
            if (payload.iss != _issuer || payload.aud != _audience)
            {
                return false; // الـ issuer أو الـ audience غير صحيحين
            }

            // التحقق من تاريخ الانتهاء (exp)
            DateTime expirationDate;
            if (!DateTime.TryParse(payload.exp.ToString(), out expirationDate))
            {
                return false; // تاريخ الانتهاء غير صالح
            }

            if (expirationDate <= DateTime.UtcNow)
            {
                return false; // التوكن انتهت صلاحيته
            }

            if (payload.type != "refresh-token")
            {
                return false;
            }

            return true; // التوكن صالح
        }

        public string ExtractUserIdFromRefreshToken(string encryptedRefreshToken)
        {
            try
            {
                // فك تشفير الـ Refresh Token
                string refreshToken = Encryption.SymmetricDecrypt(encryptedRefreshToken);

                // تقسيم التوكن إلى جزئين (payload و signature)
                var tokenParts = refreshToken.Split('.');

                if (tokenParts.Length != 2)
                {
                    throw new Exception("Invalid token format."); // التوكن غير صالح
                }

                // استخراج الـ payload من التوكن
                string payloadJson = tokenParts[0];

                // تحويل الـ payload إلى كائن لقراءته بسهولة
                var payload = JsonConvert.DeserializeObject<dynamic>(payloadJson);

                // التحقق من أن الـ userId موجود في الـ payload
                if (payload.userId == null)
                {
                    throw new Exception("userId is missing in the token.");
                }

                // إعادة الـ userId
                return payload.userId.ToString();
            }
            catch (Exception ex)
            {
                // يمكن معالجة الأخطاء هنا وفقًا لاحتياجاتك
                throw new Exception("Failed to extract userId from refresh token: " + ex.Message);
            }
        }

    }
}
