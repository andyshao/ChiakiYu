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
        /// <summary>
        ///     根据主键获取实体
        /// </summary>
        /// <param name="id">日志id</param>
        /// <returns></returns>
        public Blog GetBlog(long id)
        {
            return _blogRepository.Get(id);
        }
        /// <summary>
        ///     获取所有用户分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 根据评论数和浏览数获取前topNum条数据
        /// </summary>
        /// <param name="topNum">多少条</param>
        /// <returns></returns>
        public IEnumerable<Blog> GetBlogsList(int topNum)
        {
            var query = _blogRepository.Table;
            var source = query.OrderByDescending(n => n.CommentCount).ThenByDescending(n => n.HitCount).ThenByDescending(n => n.Id).Take(topNum);

            var result = source.ToList();
            return result;
        }

        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public Blog AddBlog(Blog blog)
        {
            return _blogRepository.Insert(blog);
        }

        /// <summary>
        ///     更新用户
        /// </summary>
        /// <param name="blog"></param>
        public Blog UpdateBlog(Blog blog)
        {
            return _blogRepository.Update(blog);
        }

        /// <summary>
        /// 添加或更新日志：不存在则添加，存在则更新
        /// </summary>
        /// <param name="blog">日志实体</param>
        /// <returns></returns>
        public Blog AddOrUpdateBlog(Blog blog)
        {
            return _blogRepository.InsertOrUpdate(blog);
        }
    }
}