using ChiakiYu.Model.Permissions;

namespace ChiakiYu.EntityFramework.Mapping.Permissions
{
    public class PermissionMapping : EntityConfiguration<Permission, string>
    {
        public PermissionMapping()
        {
            ToTable("Sys_Permissions");
        }
    }
}