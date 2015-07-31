using System;

namespace ChiakiYu.Core.Domain.Entities
{
    /// <summary>
    /// 软删除
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        ///     是否删除
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? DeletedTime { get; set; }

    }
}