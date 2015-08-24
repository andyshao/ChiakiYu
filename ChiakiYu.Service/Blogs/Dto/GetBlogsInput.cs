using ChiakiYu.Core.Data;
using ChiakiYu.Model.Blogs;

namespace ChiakiYu.Service.Blogs.Dto
{
    public class GetBlogsInput : PagingDto
    {
        /// <summary>
        /// 名字关键字
        /// </summary>
        public string NameKeyWords { get; set; }

        /// <summary>
        /// 排序条件
        /// </summary>
        public SortBy? SortBy { get; set; }
    }
}
