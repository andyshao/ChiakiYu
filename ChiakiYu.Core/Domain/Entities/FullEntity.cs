using System;

namespace ChiakiYu.Core.Domain.Entities
{
    /// <summary>
    /// 泛型实体基类
    /// 包含：自定义主键类型；创建时间；软删除
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    [Serializable]
    public abstract class FullEntity<TKey> : Entity<TKey>, ISoftDelete
    {
        protected FullEntity()
        {
            IsDeleted = false;
        }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletedTime { get; set; }
    }
}