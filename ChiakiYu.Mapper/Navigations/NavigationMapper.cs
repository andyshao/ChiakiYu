using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Navigations;

namespace ChiakiYu.Mapper.Navigations
{
    public class NavigationMapper : EntityConfiguration<Navigation, long>
    {
        public NavigationMapper()
        {
            ToTable("Sys_Navigations");
           HasKey(n=>n.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
        
    }
}