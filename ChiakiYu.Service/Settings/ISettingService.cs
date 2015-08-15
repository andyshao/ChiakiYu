using ChiakiYu.Core.Dependency;

namespace ChiakiYu.Service.Settings
{
    public interface ISettingService<T> : IDependency where T : class
    {
        /// <summary>
        ///     获取设置
        /// </summary>
        /// <returns>settings</returns>
        T Get();

        /// <summary>
        ///     保存设置
        /// </summary>
        /// <param name="settings">settings</param>
        void Save(T settings);
    }
}