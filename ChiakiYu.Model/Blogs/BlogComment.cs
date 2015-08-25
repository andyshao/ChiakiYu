using ChiakiYu.Core.Domain.Entities;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Model.Blogs
{
    /// <summary>
    ///     Represents a blog comment
    /// </summary>
    public class BlogComment : Entity<long>
    {
        /// <summary>
        ///     Gets or sets the comment text
        /// </summary>
        public string CommentContent { get; set; }

        /// <summary>
        ///     评论日志
        /// </summary>
        public virtual Blog Blog { get; set; }

        /// <summary>
        ///     评论者
        /// </summary>
        public virtual User User { get; set; }
    }
}