using ChiakiYu.EntityFramework;

namespace ChiakiYu.Mapping.Role
{
    public class RoleMapper : EntityConfiguration<Model.Roles.Role, int>
    {
        public RoleMapper()
        {
            ToTable("Sys_Roles");
        }
    }
}