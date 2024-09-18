using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.Utils
{
    public class Validation
    {

        // completed testing.
        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            if (email.Length < 5 || email.Length > 150)
                return false;

            string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

            return Regex.IsMatch(email, pattern);
        }

        // completed testing.
        public static bool IsUsernameValid(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{3,24}$";

            return Regex.IsMatch(username, pattern);
            /*
             * يقبل الحروف الانكليزية والارقام والشارحة السفلية وبطول 4 - 25.
             * يجب ان يبدأ اسم المستخدم بحرف
             */
        }

        // completed testing.
        public static bool IsPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            return password.Length >= 8 && password.Length <= 25;
            // يقبل اي شي بطول 8 - 25.
        }

        // completed testing.
        public static bool CheckLength(int minLength, int maxLength, string? text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return text.Length >= minLength && text.Length <= maxLength;
        }

        // completed testing.
        public static bool IsText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            string pattern = @"^[^\d!@#$%^&*()_+{}|:;<>,.?~\-=[\]\\]*$";

            return Regex.IsMatch(text, pattern);

            // تقبل فقط النص باي لغة.
        }

        // completed testing.
        public static bool IsInt(string number)
        {
            string pattern = @"^\d+$";

            return Regex.IsMatch(number, pattern);

            // تقبل فقط الارقام الصحيحة.
        }

        // completed testing.
        public static bool IsFloat(string number)
        {
            string pattern = @"^\d+(\.\d+)?$";

            return Regex.IsMatch(number, pattern);

            // تقبل الارقام الصحيحة والعشرية.
        }

    }
}
