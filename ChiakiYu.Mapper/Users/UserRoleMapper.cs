using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Mapping.Users
{
    public class UserRoleMapper : EntityConfiguration<UserRole, string>
    {
        public UserRoleMapper()
        {
            ToTable("Sys_UserRoles");
        }
    }
}