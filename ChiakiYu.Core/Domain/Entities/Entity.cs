using System;
using System.ComponentModel.DataAnnotations;

namespace ChiakiYu.Core.Domain.Entities
{
    /// <summary>
    /// 泛型实体基类
    /// 包含：自定义主键类型；创建时间
    /// </summary>
    /// <typeparam name="TPrimaryKey">泛型主键</typeparam>
    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        protected Entity()
        {
            CreatedTime = DateTime.Now;
        }

        /// <summary>
        ///     泛型主键
        /// </summary>
        [Key]
        public virtual TPrimaryKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}