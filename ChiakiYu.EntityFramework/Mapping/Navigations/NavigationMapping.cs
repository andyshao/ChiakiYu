using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.Model.Navigations;

namespace ChiakiYu.EntityFramework.Mapping.Navigations
{
    public class NavigationMapping : EntityConfiguration<Navigation, long>
    {
        public NavigationMapping()
        {
            ToTable("Sys_Navigations");
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
        
    }
}