using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.Users_Subscriptions
{
    public class md_NewByUser
    {
        public int UserId { get; set; }
        public int PlanId { get; set; }

        public md_NewByUser(int userId, int planId)
        {
            UserId = userId;
            PlanId = planId;
        }
    }
}
