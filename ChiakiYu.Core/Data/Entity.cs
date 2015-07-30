using System;
using System.ComponentModel.DataAnnotations;

namespace ChiakiYu.Core.Data
{
    /// <summary>
    /// 泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">泛型主键</typeparam>
    [Serializable]
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        ///     泛型主键
        /// </summary>
        [Key]
        public virtual TPrimaryKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreatedTime { get; set; }
    }
}