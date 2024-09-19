using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Errors
{
    public class md_NewError
    {

        public string Message { get; set; }
        public string Layer { get; set; }
        public string Source { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string StackTrace { get; set; }
        public string? Description { get; set; }
        public string? Params { get; set; }

        public md_NewError
            (
                string message, string layer, string source, string _class,
                string method, string stackTrance, string? description, string? _params
            )
        {
            Message = message;
            Layer = layer;
            Source = source;
            Class = _class;
            Method = method;
            StackTrace = stackTrance;
            Description = description;
            Params = _params;
        }

    }
}
