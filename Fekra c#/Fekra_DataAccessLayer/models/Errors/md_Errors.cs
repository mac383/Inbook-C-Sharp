using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Errors
{
    public class md_Errors
    {

        public int ErrorId { get; set; }
        public DateTime ErrorDate { get; set; }
        public string ErrorMessage { get; set; }
        public string Layer { get; set; }
        public string Class { get; set; }
        public bool IsHandled { get; set; }
        public string Method { get; set; }

        public md_Errors(int errorId, DateTime errorDate, string errorMessage, string layer, string _class, bool isHandled, string method)
        {
            ErrorId = errorId;
            ErrorDate = errorDate;
            ErrorMessage = errorMessage;
            Layer = layer;
            Class = _class;
            IsHandled = isHandled;
            Method = method;
        }

    }
}
