using System.Collections.Generic;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Model.Navigations;

namespace ChiakiYu.Service.Navigations
{
    /// <summary>
    /// 导航Service接口
    /// </summary>
    public interface INavigationService : IDependency 
    {
        /// <summary>
        ///     根据某个区域的导航
        /// </summary>
        /// <param name="presentArea">区域</param>
        /// <returns></returns>
        List<Navigation> GetNavigations(PresentArea presentArea);
    }
}