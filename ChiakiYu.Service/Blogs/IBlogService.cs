using System.Collections.Generic;
using ChiakiYu.Core.Data;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Model.Blogs;
using ChiakiYu.Service.Blogs.Dto;

namespace ChiakiYu.Service.Blogs
{
    public interface IBlogService : IDependency
    {
        /// <summary>
        ///     根据主键获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Blog GetBlog(long id);

        /// <summary>
        ///     获取所有用户分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagingList<Blog> GetBlogs(GetBlogsInput input);

        /// <summary>
        /// 根据评论数和浏览数获取前topNum条数据
        /// </summary>
        /// <param name="topNum">多少条</param>
        /// <returns></returns>
        IEnumerable<Blog> GetBlogsList(int topNum);

        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        Blog AddBlog(Blog blog);

        /// <summary>
        ///     更新用户
        /// </summary>
        /// <param name="blog"></param>
        Blog UpdateBlog(Blog blog);

        Blog AddOrUpdateBlog(Blog blog);
    }
}