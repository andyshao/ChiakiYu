using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Permissions;

namespace ChiakiYu.Mapping.Permissions
{
    public class PermissionMapping : EntityConfiguration<Permission, string>
    {
        public PermissionMapping()
        {
            ToTable("Sys_Permissions");
        }
    }
}