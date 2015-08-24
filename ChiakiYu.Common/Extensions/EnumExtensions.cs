using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        ///     获取枚举项上设置的显示文字
        /// </summary>
        /// <param name="value">被扩展对象</param>
        public static string EnumMetadataDisplay(this Enum value)
        {
            var name = Enum.GetName(value.GetType(), value);
            if (string.IsNullOrEmpty(name))
                return value.ToString();
            var attribute = value.GetType().GetField(name).GetCustomAttributes(
                typeof (DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .FirstOrDefault();
            if (attribute != null)
                return attribute.Name;

            return value.ToString();
        }
    }
}