using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.Utils.Notifications
{
    public interface INotification
    {
        // completed testing.
        public Task<string?> SendEmailVerification(string to, string messageHeader, string messageBody, string VerificationKey);
    }
}
