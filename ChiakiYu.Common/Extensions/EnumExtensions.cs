using System;
using System.ComponentModel;
using System.Linq;

namespace ChiakiYu.Common.Extensions
{
    /// <summary>
    ///     枚举<see cref="Enum" />的扩展辅助操作方法
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     获取枚举项上的<see cref="DescriptionAttribute" />特性的文字描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            var type = value.GetType();
            var member = type.GetMember(value.ToString()).FirstOrDefault();
            return member != null ? member.ToDescription() : value.ToString();
        }
    }
}