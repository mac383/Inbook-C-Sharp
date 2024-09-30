using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.System_Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_SystemPermissions
    {
        // completed testing.
        public static async Task<List<md_SystemPermissions>?> GetPermissionsByAdminAsync(int adminId)
        {
            return await cls_SystemPermissions_D.GetPermissionsByAdminAsync(adminId);
        }
    }
}
