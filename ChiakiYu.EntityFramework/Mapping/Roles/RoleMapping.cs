namespace ChiakiYu.EntityFramework.Mapping.Roles
{
    public class RoleMapping : EntityConfiguration<Model.Roles.Role, int>
    {
        public RoleMapping()
        {
            ToTable("Sys_Roles");
        }
    }
}