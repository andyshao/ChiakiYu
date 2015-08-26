using System.Collections.Generic;
using System.Linq;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Navigations;

namespace ChiakiYu.Service.Navigations
{
    /// <summary>
    /// 导航Service
    /// </summary>
    public class NavigationService : INavigationService
    {
        private readonly IRepository<Navigation, long> _navigationRepository;

        public NavigationService(IRepository<Navigation, long> navigationRepository)
        {
            _navigationRepository = navigationRepository;
        }

        /// <summary>
        ///     根据某个区域的导航
        /// </summary>
        /// <param name="presentArea">区域</param>
        /// <returns></returns>
        public List<Navigation> GetNavigations(PresentArea presentArea)
        {
            var query = _navigationRepository.Table.Where(n => n.PresentArea == presentArea);
            return query.Where(n => n.IsEnabled && !n.IsDeleted).OrderBy(n => n.Level).ThenBy(n => n.Order).ToList();
        }
    }
}