using System.Collections.Generic;
using System.Linq;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Navigations;

namespace ChiakiYu.Service.Navigations
{
    public class NavigationService : INavigationService
    {
        private readonly IRepository<Navigation, long> _navigationRepository;

        public NavigationService(IRepository<Navigation, long> navigationRepository)
        {
            _navigationRepository = navigationRepository;
        }

        public List<Navigation> GetNavigations()
        {
            var query = _navigationRepository.GetAll();
            return query.OrderBy(n => n.Level).ToList();
        }

        public List<Navigation> GetNavigations(PresentArea presentArea)
        {
            var query = _navigationRepository.GetAll().Where(n => n.PresentArea == presentArea);
            return query.OrderBy(n => n.Level).ToList();
        }
    }
}