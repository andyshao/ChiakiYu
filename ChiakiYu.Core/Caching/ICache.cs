using System;

namespace ChiakiYu.Core.Caching
{
    /// <summary>
    ///     缓存接口
    /// </summary>
    public interface ICache
    {
        /// <summary>
        ///     获取缓存项
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存项标识</param>
        /// <returns>返回cacheKey对应的缓存项，如果不存在则返回null</returns>
        T Get<T>(string key);

        /// <summary>
        ///     如果不存在缓存项则添加，否则更新
        /// </summary>
        /// <param name="key">缓存项标识</param>
        /// <param name="value">缓存项</param>
        /// <param name="timeSpan">缓存失效时间</param>
        void Set(string key, object value, TimeSpan timeSpan);

        /// <summary>
        ///     是否缓存项已存在
        /// </summary>
        /// <param name="key">缓存项标识</param>
        /// <returns></returns>
        bool IsSet(string key);

        /// <summary>
        ///     移除缓存项
        /// </summary>
        /// <param name="key">缓存项标识</param>
        void Remove(string key);

        /// <summary>
        ///     清空缓存
        /// </summary>
        void Clear();
    }
}