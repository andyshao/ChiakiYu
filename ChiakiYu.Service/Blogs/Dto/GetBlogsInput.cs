using ChiakiYu.Core.Data;

namespace ChiakiYu.Service.Blogs.Dto
{
    public class GetBlogsInput : PagingDto
    {
        /// <summary>
        /// 名字关键字
        /// </summary>
        public string NameKeyWords { get; set; }

    }
}
