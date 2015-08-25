using ChiakiYu.Model.Blogs;

namespace ChiakiYu.EntityFramework.Mapping.Blogs
{
    public class BlogCommentMapping : EntityConfiguration<BlogComment, long>
    {
        public BlogCommentMapping()
        {
            ToTable("BlogComments");
            HasRequired(n => n.User).WithMany().Map(n => n.MapKey("User"));
            HasRequired(n => n.Blog).WithMany(n => n.BlogComments).Map(n => n.MapKey("Blog"));
        }
    }
}