using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Sessions
{
    public class md_NewSession
    {
        public string Key { get; set; }
        public int UserId { get; set; }

        public md_NewSession(string key, int userId)
        {
            Key = key;
            UserId = userId;
        }
    }
}
