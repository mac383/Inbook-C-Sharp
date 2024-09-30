using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.models.System_Permissions
{
    public class md_SystemPermissions
    {
        public string PermissionName { get; set; }
        public long PermissionValus { get; set; }

        public md_SystemPermissions(string permissionName, long permissionValue)
        {
            PermissionName = permissionName;
            PermissionValus = permissionValue;
        }
    }
}
