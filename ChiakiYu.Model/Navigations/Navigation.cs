using System.ComponentModel.DataAnnotations;
using ChiakiYu.Core.Data;

namespace ChiakiYu.Model.Navigations
{
    /// <summary>
    ///     导航
    /// </summary>
    public class Navigation : Entity<int>, ISoftDelete
    {

        #region 持久化属性
        /// <summary>
        ///     导航名称
        /// </summary>
        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        /// <summary>
        ///     导航所在区域
        /// </summary>
        public PresentArea PresentArea { get; set; }

        /// <summary>
        ///     导航级别（1级导航，2级导航...）
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     父级导航
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        ///     导航url
        /// </summary>
        [StringLength(256)]
        public string Url { get; set; }

        /// <summary>
        ///     图标名称
        /// </summary>
        [StringLength(128)]
        public string IconName { get; set; }

        /// <summary>
        ///     排序序号
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///     是否启用
        /// </summary>
        public bool IsEnabled { get; set; }
        #endregion

        public bool IsDeleted { get; set; }
    }
}