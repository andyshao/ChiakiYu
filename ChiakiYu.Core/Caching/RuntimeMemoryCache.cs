using System;
using System.Runtime.Caching;

namespace ChiakiYu.Core.Caching
{
    /// <summary>
    ///     使用System.Runtime.Caching.MemoryCache实现的本机缓存
    /// </summary>
    public class RuntimeMemoryCache : ICache
    {
        private readonly MemoryCache _cache = MemoryCache.Default;

        /// <summary>
        ///     获取缓存项
        /// </summary>
        /// <param name="key">缓存项标识</param>
        /// <returns>缓存项</returns>
        public virtual T Get<T>(string key)
        {
            return (T) _cache[key];
        }

        /// <summary>
        ///     如果不存在缓存项则添加，否则更新
        /// </summary>
        /// <param name="key">缓存项标识</param>
        /// <param name="value">缓存项</param>
        /// <param name="timeSpan">缓存失效时间</param>
        public virtual void Set(string key, object value, TimeSpan timeSpan)
        {
            _cache.Set(key, value, DateTimeOffset.Now.Add(timeSpan));
        }

        /// <summary>
        ///     是否缓存项已存在
        /// </summary>
        /// <param name="key">缓存项标识</param>
        /// <returns></returns>
        public virtual bool IsSet(string key)
        {
            return _cache.Contains(key);
        }

        /// <summary>
        ///     移除指定的缓存项
        /// </summary>
        /// <param name="key">要移除的缓存项标识</param>
        public virtual void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        ///     从缓存中清除所有缓存项
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in _cache)
            {
                _cache.Remove(item.Key);
            }
        }
    }
}