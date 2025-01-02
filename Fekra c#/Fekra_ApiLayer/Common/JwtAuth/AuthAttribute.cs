using Fekra_BusinessLayer.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Fekra_ApiLayer.Common.JwtAuth
{
    public class AuthAttribute : ActionFilterAttribute
    {
        private readonly cls_JwtAuth _jwtAuth;

        public AuthAttribute()
        {
            _jwtAuth = new cls_JwtAuth(); // يمكن استخدام الـ Dependency Injection في حالة رغبتك.
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                // تحقق من وجود التوكن في الهيدر
                if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
                {
                    context.Result = new UnauthorizedObjectResult("Authorization token is missing.");
                    return;
                }

                // حذف الـ Bearer إذا كان موجودًا في التوكن (إن كان موجودًا)
                string cleanToken = token.ToString().Replace("Bearer ", "").Trim();

                // التحقق من التوكن
                bool isValid = _jwtAuth.ValidateAccessToken(cleanToken);

                if (!isValid)
                {
                    context.Result = new UnauthorizedObjectResult("Invalid or expired token.");
                    return;
                }

                // إذا كان التوكن صالحًا، السماح بالوصول
                base.OnActionExecuting(context);
            }
            catch (Exception ex)
            {
                // في حالة حدوث أي استثناء، إرجاع خطأ داخلي مع تفاصيل الاستثناء
                context.Result = new ObjectResult("An error occurred while processing the token: " + ex.Message)
                {
                    StatusCode = 500 // تحديد حالة الخطأ كـ 500 (Internal Server Error)
                };
            }
        }
    }
}
