using Fekra_DataAccessLayer.classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Errors
{
    public class md_Error
    {

        public int ErrorId { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Message { get; set; }
        public string Layer { get; set; }
        public string Source { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string StackTrace { get; set; }
        public bool IsHandled { get; set; }
        public string? Description { get; set; }
        public string? Params { get; set; }
        public string ErrorKey { get; set; }

        public md_Error
            (
            int errorId, DateTime errorDate, string message, string layer, string source, string _class,
            string method, string stackTrace, bool isHandled, string? description, string? _params, string errorKey
            )
        {
            ErrorId = errorId;
            ErrorDate = errorDate;
            Message = message;
            Layer = layer;
            Source = source;
            Class = _class;
            Method = method;
            StackTrace = stackTrace;
            IsHandled = isHandled;
            Description = description;
            Params = _params;
            ErrorKey = errorKey;
        }

    }
}
