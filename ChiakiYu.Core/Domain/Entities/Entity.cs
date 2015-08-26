using System;
using System.ComponentModel.DataAnnotations;

namespace ChiakiYu.Core.Domain.Entities
{
    /// <summary>
    ///     泛型实体基类
    ///     包含：自定义主键类型；创建时间
    /// </summary>
    /// <typeparam name="TKey">泛型主键</typeparam>
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        protected Entity()
        {
            CreatedTime = DateTime.Now;
        }

        /// <summary>
        ///     泛型主键
        /// </summary>
        [Key]
        public virtual TKey Id { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        #region 方法

        /// <summary>
        ///     判断两个实体是否是同一数据记录的实体
        /// </summary>
        /// <param name="obj">要比较的实体信息</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var entity = obj as Entity<TKey>;
            if (entity == null)
            {
                return false;
            }
            return Id.Equals(entity.Id) && CreatedTime.Equals(entity.CreatedTime);
        }

        /// <summary>
        ///     用作特定类型的哈希函数。
        /// </summary>
        /// <returns>
        ///     当前 <see cref="T:System.Object" /> 的哈希代码。
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ CreatedTime.GetHashCode();
        }

        #endregion
    }
}