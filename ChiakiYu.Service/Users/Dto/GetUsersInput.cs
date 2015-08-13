using ChiakiYu.Core.Data;

namespace ChiakiYu.Service.Users.Dto
{
    public class GetUsersInput : PagingDto
    {
        /// <summary>
        /// 名字关键字
        /// </summary>
        public string NameKeyWords { get; set; }

        /// <summary>
        /// 邮箱地址关键字
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 是否已激活
        /// </summary>
        public bool? IsActive { get; set; }

    }
}
