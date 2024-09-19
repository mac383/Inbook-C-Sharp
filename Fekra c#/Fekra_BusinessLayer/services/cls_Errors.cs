using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_Errors
    {

        // completed testing.
        public static async Task<bool> LogErrorAsync(md_NewError error)
        {
            return await cls_Errors_D.LogErrorAsync(error);
        }

        // completed testing.
        public static string GetParams(params Expression<Func<object?>>[] expressions)
        {
            return cls_Errors_D.GetParams(expressions);
        }

        // completed testing.
        public static async Task<bool> SetAsHandledAsync(int errorId, int byAdmin)
        {
            return await cls_Errors_D.SetAsHandledAsync(errorId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> SetDescriptionAsync(int errorId, string description, int byAdmin)
        {
            return await cls_Errors_D.SetDescriptionAsync(errorId, description, byAdmin);
        }

        // completed testing.
        public static async Task<int> GetPagesCount_All_Async()
        {
            return await cls_Errors_D.GetPagesCount_All_Async();
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Handled_Async()
        {
            return await cls_Errors_D.GetPagesCount_Handled_Async();
        }

        // completed testing.
        public static async Task<int> GetPagesCount_NotHandled_Async()
        {
            return await cls_Errors_D.GetPagesCount_NotHandled_Async();
        }

        // completed testing.
        public static async Task<List<md_Errors>?> GetAll(int pageNumber)
        {
            return await cls_Errors_D.GetAll(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Errors>?> GetHandledErrorsAsync(int pageNumber)
        {
            return await cls_Errors_D.GetHandledErrorsAsync(pageNumber);
        }

        // completed testing.
        public static async Task<List<md_Errors>?> GetNotHandledErrorsAsync(int pageNumber)
        {
            return await cls_Errors_D.GetNotHandledErrorsAsync(pageNumber);
        }

        // completed testing.
        public static async Task<md_Error?> GetById(int errorId)
        {
            return await cls_Errors_D.GetById(errorId);
        }

        // completed testing.
        public static async Task<md_Error?> GetByKey(string key)
        {
            return await cls_Errors_D.GetByKey(key);
        }
    }
}
