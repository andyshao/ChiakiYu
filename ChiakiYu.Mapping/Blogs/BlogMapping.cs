using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Blogs;

namespace ChiakiYu.Mapping.Blogs
{
    public class BlogMapping : EntityConfiguration<Blog, long>
    {
        public BlogMapping()
        {
            ToTable("Blogs");
            HasRequired(n => n.Author).WithMany().Map(n => n.MapKey("Author"));
        }
    }
}