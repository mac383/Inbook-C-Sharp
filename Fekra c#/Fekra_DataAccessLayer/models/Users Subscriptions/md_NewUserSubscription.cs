using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users_Subscriptions
{
    public class md_NewUserSubscription
    {
        public int UserId { get; set; }
        public int PlanId { get; set; }
        public int ByAdmin { get; set; }

        public md_NewUserSubscription (int userId, int planId, int byAdmin)
        {
            UserId = userId;
            PlanId = planId;
            ByAdmin = byAdmin;
        }
    }
}
