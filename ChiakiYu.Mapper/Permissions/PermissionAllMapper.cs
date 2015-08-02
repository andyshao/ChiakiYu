using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Permissions;

namespace ChiakiYu.Mapper.Permissions
{
    public class PermissionAllMapper : EntityConfiguration<PermissionAll, int>
    {
        public PermissionAllMapper()
        {
            ToTable("Sys_PermissionsAll");
            HasKey(n => n.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}