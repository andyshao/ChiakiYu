using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Permissions;

namespace ChiakiYu.Mapping.Permissions
{
    public class PermissionSiteMapping : EntityConfiguration<PermissionSite, int>
    {
        public PermissionSiteMapping()
        {
            ToTable("Sys_Permissions_Site");
            HasKey(n => n.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}