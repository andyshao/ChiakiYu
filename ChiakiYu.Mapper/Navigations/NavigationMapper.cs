using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Navigations;

namespace ChiakiYu.Mapper.Navigations
{
    public class NavigationMapper : EntityConfiguration<Navigation, long>
    {
        public NavigationMapper()
        {
            ToTable("Sys_Navigations");
        }
        
    }
}