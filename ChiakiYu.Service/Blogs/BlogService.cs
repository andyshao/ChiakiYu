using System.Linq;
using ChiakiYu.Core.Data;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Blogs;
using ChiakiYu.Service.Blogs.Dto;

namespace ChiakiYu.Service.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog, long> _blogRepository;

        public BlogService(IRepository<Blog, long> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public Blog GetBlog(long id)
        {
            return _blogRepository.Get(id);
        }

        public PagingList<Blog> GetUsers(GetBlogsInput input)
        {
            var query = _blogRepository.Table;
            if (!string.IsNullOrWhiteSpace(input.NameKeyWords))
                query = query.Where(m => m.Title.Contains(input.NameKeyWords) || m.Summary.Contains(input.NameKeyWords));
            var source = query.OrderBy(n => n.Id)
                .Skip((input.PageIndex - 1)*input.PageSize)
                .Take(input.PageSize);

            var result = new PagingList<Blog>(source, input.PageIndex, input.PageSize, query.LongCount());
            return result;
        }

        public Blog AddBlog(Blog blog)
        {
            return _blogRepository.Insert(blog);
        }

        public Blog UpdateBlog(Blog blog)
        {
            return _blogRepository.Update(blog);
        }

        public Blog AddOrUpdateBlog(Blog blog)
        {
            return _blogRepository.InsertOrUpdate(blog);
        }
    }
}