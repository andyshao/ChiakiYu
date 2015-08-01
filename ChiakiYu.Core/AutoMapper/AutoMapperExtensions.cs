using AutoMapper;

namespace ChiakiYu.Core.AutoMapper
{
    /// <summary>
    /// AutoMapper 辅助扩展方法
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// 创建映射，使用源对象创建目标对象
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <returns>创建的目标对象</returns>
        public static TDestination MapTo<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// 更新映射，使用源对象更新目标对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="destination">要更新的目标对象</param>
        /// <returns>更新后的目标对象</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}
