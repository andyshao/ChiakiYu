using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ChiakiYu.Core.Domain.Entities;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Model.Blogs
{
    public class Blog : FullEntity<long>
    {
        private ICollection<BlogComment> _blogComments;

        /// <summary>
        ///     日志标题
        /// </summary>
        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        /// <summary>
        ///     日志内容
        /// </summary>
        [Required]
        [AllowHtml]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        /// <summary>
        ///     摘要
        /// </summary>
        [StringLength(512)]
        public string Summary { get; set; }

        /// <summary>
        ///     标题图文件（带部分路径）
        /// </summary>
        [StringLength(256)]
        public string FeaturedImage { get; set; }

        /// <summary>
        ///     日志作者
        /// </summary>
        public virtual User Author { get; set; }

        /// <summary>
        ///     是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        ///     是否锁定（锁定的日志不允许评论）
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        ///     是否开启评论后查看
        /// </summary>
        public bool IsViewAfterComment { get; set; }

        /// <summary>
        ///     评论数
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        ///     浏览数
        /// </summary>
        public int HitCount { get; set; }

        /// <summary>
        ///     更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }

        /// <summary>
        /// 日志评论列表
        /// </summary>
        public virtual ICollection<BlogComment> BlogComments
        {
            get { return _blogComments ?? (_blogComments = new List<BlogComment>()); }
            protected set { _blogComments = value; }
        }
    }
}