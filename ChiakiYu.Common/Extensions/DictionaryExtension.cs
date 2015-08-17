using System.Collections.Generic;
using ChiakiYu.Common.Data;

namespace ChiakiYu.Common.Extensions
{
    /// <summary>
    /// IDictionary扩展
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// 依据key获取字典的value，并转换为需要的类型
        /// </summary>
        /// <remarks>
        /// <para>常用于以下集合：</para>
        /// <list type="number">
        /// <item>ViewData</item>
        /// <item>NameValueCollection：HttpRequest.Form、HttpRequest.Request、HttpRequest.Params</item>
        /// </list>
        /// </remarks>
        /// <param name="dictionary">字典集合</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果未找到则返回该默认值</param>
        /// <returns>取得viewdata里的某个值,并且转换成指定的对象类型,如果不是该类型或如果是一个数组类型而元素为0个或没有此key都将返回空,</returns>
        public static T Get<T>(this IDictionary<string, object> dictionary, string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
            {
                object value;
                dictionary.TryGetValue(key, out value);

                return ValueHelper.ChangeType<T>(value, defaultValue);
            }
            return defaultValue;
        }



    }
}
