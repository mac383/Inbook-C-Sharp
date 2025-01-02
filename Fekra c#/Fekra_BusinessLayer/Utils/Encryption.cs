using Fekra_DataAccessLayer;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Fekra_BusinessLayer.Utils
{
    public class Encryption
    {

        public static string HashEncrypt(string plainText)
        {
            string salt = "salt";

            plainText += salt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static string SymmetricEncrypt(string plainText)
        {
            string key = "0123456789abcdef"; // تأكد من تطابق طول المفتاح مع متطلبات AES

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = new byte[16]; // حجم IV ل AES هو 16 بايت

            // إنشاء IV عشوائي باستخدام RandomNumberGenerator
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(ivBytes);
            }

            using (Aes aesAlgor = Aes.Create())
            {
                aesAlgor.Key = keyBytes;
                aesAlgor.IV = ivBytes;

                ICryptoTransform encryptor = aesAlgor.CreateEncryptor(aesAlgor.Key, aesAlgor.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    // كتابة IV في بداية النص المشفر
                    msEncrypt.Write(ivBytes, 0, ivBytes.Length);

                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string SymmetricDecrypt(string encryptedText)
        {
            string key = "0123456789abcdef"; // تأكد من تطابق المفتاح مع مفتاح التشفير

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            // تحويل النص المشفر من قاعدة 64 إلى مصفوفة بايت
            byte[] cipherBytes = Convert.FromBase64String(encryptedText);

            // قراءة IV من بداية النص المشفر
            byte[] ivBytes = new byte[16]; // حجم IV ل AES هو 16 بايت
            Array.Copy(cipherBytes, 0, ivBytes, 0, ivBytes.Length);

            // قراءة النص المشفر بعد IV
            byte[] encryptedBytes = new byte[cipherBytes.Length - ivBytes.Length];
            Array.Copy(cipherBytes, ivBytes.Length, encryptedBytes, 0, encryptedBytes.Length);

            using (Aes aesAlgor = Aes.Create())
            {
                aesAlgor.Key = keyBytes;
                aesAlgor.IV = ivBytes;

                ICryptoTransform decryptor = aesAlgor.CreateDecryptor(aesAlgor.Key, aesAlgor.IV);

                using (var msDecrypt = new System.IO.MemoryStream(encryptedBytes))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
