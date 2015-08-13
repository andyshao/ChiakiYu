using System;

namespace ChiakiYu.Core.Domain.Entities
{
    /// <summary>
    /// 泛型实体接口
    /// </summary>
    /// <typeparam name="TKey">泛型主键</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreatedTime { get; set; }
    }
}
