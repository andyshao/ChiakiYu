
using System;
using System.Collections.Generic;

namespace ChiakiYu.Common.Data
{
    /// <summary>
    ///     用于类型转换的工具类
    /// </summary>
    public static class ValueHelper
    {
        /// <summary>
        ///     把字符串数组转换成整型列表
        /// </summary>
        /// <param name="strArray">需要转换的字符串数组</param>
        /// <returns>根据字符串数据转换后的数值集合</returns>
        public static List<int> ParseInt(string[] strArray)
        {
            var result = new List<int>();

            if (strArray == null || strArray.Length == 0)
                return result;

            foreach (var str in strArray)
            {
                var tempInt = 0;
                if (int.TryParse(str, out tempInt))
                    result.Add(tempInt);
            }
            return result;
        }

        /// <summary>
        ///     把value转换成类型为T的数据，无法进行转换时返回defaultValue
        /// </summary>
        /// <typeparam name="T">需转换的类型</typeparam>
        /// <param name="value">待转换的数据</param>
        /// <returns>转换后的数据</returns>
        public static T ChangeType<T>(object value)
        {
            return ChangeType(value, default(T));
        }

        /// <summary>
        ///     把value转换成类型为T的数据，无法进行转换时返回defaultValue
        /// </summary>
        /// <typeparam name="T">需转换的类型参数</typeparam>
        /// <param name="value">待转换的数据</param>
        /// <param name="defalutValue">无法转换时需返回的默认值</param>
        /// <returns>转换后的数据</returns>
        public static T ChangeType<T>(object value, T defalutValue)
        {
            if (value != null)
            {
                var tType = typeof (T);
                if (tType.IsInterface || (tType.IsClass && tType != typeof (string)))
                {
                    if (value is T)
                        return (T) value;
                }
                else if (tType.IsGenericType && tType.GetGenericTypeDefinition() == typeof (Nullable<>))
                {
                    return (T) Convert.ChangeType(value, Nullable.GetUnderlyingType(tType));
                }
                else if (tType.IsEnum)
                {
                    return (T) Enum.Parse(tType, value.ToString());
                }
                else
                {
                    return (T) Convert.ChangeType(value, tType);
                }
            }
            return defalutValue;
        }

        
    }
}