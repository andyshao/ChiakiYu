using System.ComponentModel.DataAnnotations;

namespace ChiakiYu.Model.Blogs
{
    public enum SortBy
    {
        /// <summary>
        ///     发布时间正序
        /// </summary>
        [Display(Name = "发布时间正序")]
        CreatedTime,

        /// <summary>
        ///     发布时间倒序
        /// </summary>
        [Display(Name = "发布时间倒序")]
        CreatedTimeDesc,

        /// <summary>
        ///     更新时间倒序
        /// </summary>
        [Display(Name = "更新时间倒序")]
        UpdatedTimeDesc,

        /// <summary>
        ///     浏览数
        /// </summary>
        [Display(Name = "浏览数")]
        HitCount,

        /// <summary>
        ///     评论数
        /// </summary>
        [Display(Name = "评论数")]
        CommentCount
    }
}