using AutoMapper;

namespace ChiakiYu.Core.AutoMapper
{
    public static class AutoMapperHelper
    {
        /// <summary>
        ///     创建映射
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        public static void CreateMap<TSource, TDestination>()
        {
            Mapper.CreateMap<TSource, TDestination>();
        }
    }
}