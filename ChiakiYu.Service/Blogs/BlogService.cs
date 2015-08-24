using System.Collections.Generic;
using System.Data.Entity;
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

        public PagingList<Blog> GetBlogs(GetBlogsInput input)
        {
            var query = _blogRepository.Table;
            if (!string.IsNullOrWhiteSpace(input.NameKeyWords))
                query = query.Where(m => m.Title.Contains(input.NameKeyWords) || m.Summary.Contains(input.NameKeyWords));
            if (input.SortBy.HasValue)
            {
                switch (input.SortBy.Value)
                {
                    case SortBy.CreatedTime:
                        query = query.OrderBy(n => n.Id);
                        break;
                    case SortBy.CreatedTimeDesc:
                        query = query.OrderByDescending(n => n.Id);
                        break;
                    case SortBy.UpdatedTimeDesc:
                        query = query.OrderByDescending(n => n.UpdatedTime);
                        break;
                    case SortBy.CommentCount:
                        query = query.OrderByDescending(n => n.CommentCount);
                        break;
                    case SortBy.HitCount:
                        query = query.OrderByDescending(n => n.HitCount);
                        break;
                    default:
                        query = query.OrderByDescending(n => n.IsTop).ThenByDescending(n => n.Id);
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(n => n.IsTop).ThenByDescending(n => n.Id);
            }
            var source = query
                .Include(n => n.Author).Skip((input.PageIndex - 1) * input.PageSize)
                .Take(input.PageSize);

            var result = new PagingList<Blog>(source, input.PageIndex, input.PageSize, query.LongCount());
            return result;
        }

        public IEnumerable<Blog> GetBlogsList(int topNum)
        {
            var query = _blogRepository.Table;
            var source = query.OrderByDescending(n => n.CommentCount).ThenByDescending(n => n.HitCount).ThenByDescending(n => n.Id).Take(topNum);

            var result = source.ToList();
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