using ChiakiYu.Model.Users;

namespace ChiakiYu.EntityFramework.Mapping.Users
{
    public class UserRoleMapping : EntityConfiguration<UserRole, string>
    {
        public UserRoleMapping()
        {
            ToTable("Sys_UserRoles");
        }
    }
}