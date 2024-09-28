using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Sessions
{
    public class md_Sessions
    {
        public int SessionId { get; set; }
        public string SessionKey { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public md_Sessions(int sessionId, string sessionKey, bool isActive, string userName, string email)
        {
            SessionId = sessionId;
            SessionKey = sessionKey;
            IsActive = isActive;
            UserName = userName;
            Email = email;
        }
    }
}
