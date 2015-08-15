using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Navigations;

namespace ChiakiYu.Mapping.Navigations
{
    public class NavigationMapping : EntityConfiguration<Navigation, long>
    {
        public NavigationMapping()
        {
            ToTable("Sys_Navigations");
           HasKey(n=>n.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
        
    }
}