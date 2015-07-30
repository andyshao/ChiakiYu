using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Navigations;

namespace ChiakiYu.Mapper.Navigations
{
    public class NavigationMapper : EntityConfiguration<Navigation,int>
    {
        public NavigationMapper()
        {
            ToTable("Sys_Navigations");
        }
    }
}