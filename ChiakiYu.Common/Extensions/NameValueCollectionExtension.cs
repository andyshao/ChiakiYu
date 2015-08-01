using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ChiakiYu.Common.Extensions
{
    /// <summary>
    ///     获取Request.QueryString[key],Request.Form[key],Request.Params[key]并进行类型转换
    /// </summary>
    public static class NameValueCollectionExtension
    {
        /// <summary>
        ///     获取请求的参数
        /// </summary>
        /// <typeparam name="T">必须是基本类型</typeparam>
        /// <param name="collection"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this NameValueCollection collection, string key)
        {
            return typeof (T) == typeof (string)
                ? Get(collection, key, (T) Convert.ChangeType(string.Empty, typeof (T)))
                : Get(collection, key, default(T));
        }

        /// <summary>
        ///     获取请求的参数
        /// </summary>
        /// <typeparam name="T">必须是基本类型</typeparam>
        /// <param name="collection"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T Get<T>(this NameValueCollection collection, string key, T defaultValue)
        {
            var returnValue = defaultValue;
            if (collection[key] == null) return returnValue;
            var tType = typeof (T);
            if (tType.IsGenericType && tType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                if (string.IsNullOrEmpty(collection[key]))
                    return defaultValue;
                return
                    (T) TypeDescriptor.GetConverter(Nullable.GetUnderlyingType(tType)).ConvertFrom(collection[key]);
            }
            if (tType.IsEnum)
            {
                return (T) Enum.Parse(tType, collection[key]);
            }
            try
            {
                return (T) Convert.ChangeType(collection[key], tType);
            }
            catch
            {
                return returnValue;
            }
        }

        /// <summary>
        ///     获取请求中的集合数据
        /// </summary>
        /// <typeparam name="T">必须是基本类型</typeparam>
        /// <param name="collection">被扩展集合</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static IEnumerable<T> Gets<T>(this NameValueCollection collection, string key)
        {
            return Gets(collection, key, default(IEnumerable<T>));
        }

        /// <summary>
        ///     获取请求中的集合数据
        /// </summary>
        /// <typeparam name="T">必须是基本类型</typeparam>
        /// <param name="collection">被扩展集合</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static IEnumerable<T> Gets<T>(this NameValueCollection collection, string key,
            IEnumerable<T> defaultValue)
        {
            if (collection[key] == null) return defaultValue;
            if (string.IsNullOrEmpty(collection[key])) return defaultValue;
            IList<T> iVal = new List<T>();
            var strValArray = collection[key].Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var val in strValArray)
            {
                try
                {
                    iVal.Add((T) Convert.ChangeType(val, typeof (T)));
                }
                catch
                {
                    // ignored
                }
            }

            return iVal;
        }

        /// <summary>
        ///     获取Guid类型值
        /// </summary>
        /// <param name="collection">NameValueCollection</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">默认返回值</param>
        public static Guid GetGuid(this NameValueCollection collection, string key, Guid defaultValue)
        {
            var returnValue = defaultValue;
            if (string.IsNullOrEmpty(collection[key])) return returnValue;
            try
            {
                returnValue = new Guid(collection[key]);
            }
            catch
            {
                // ignored
            }

            return returnValue;
        }
    }
}