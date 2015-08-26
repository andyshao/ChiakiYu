using ChiakiYu.Core.Dependency;

namespace ChiakiYu.Service.Settings
{
    /// <summary>
    /// 设置Service接口
    /// </summary>
    /// <typeparam name="T">设置的实体类型</typeparam>
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