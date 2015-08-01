using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Permissions;

namespace ChiakiYu.Mapper.Permissions
{
    public class PermissionMapper : EntityConfiguration<Permission, string>
    {
        public PermissionMapper()
        {
            ToTable("Sys_Permissions");
        }
    }
}