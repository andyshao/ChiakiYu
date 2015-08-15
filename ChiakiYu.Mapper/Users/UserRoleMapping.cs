using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Mapping.Users
{
    public class UserRoleMapping : EntityConfiguration<UserRole, string>
    {
        public UserRoleMapping()
        {
            ToTable("Sys_UserRoles");
        }
    }
}