using ChiakiYu.EntityFramework;

namespace ChiakiYu.Mapping.Roles
{
    public class RoleMapping : EntityConfiguration<Model.Roles.Role, int>
    {
        public RoleMapping()
        {
            ToTable("Sys_Roles");
        }
    }
}