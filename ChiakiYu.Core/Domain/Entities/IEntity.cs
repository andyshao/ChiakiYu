using System;

namespace ChiakiYu.Core.Domain.Entities
{
    /// <summary>
    /// 泛型实体接口
    /// </summary>
    /// <typeparam name="TPrimaryKey">泛型主键</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreatedTime { get; set; }
    }
}
