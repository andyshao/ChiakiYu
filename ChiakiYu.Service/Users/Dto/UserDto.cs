using System;

namespace ChiakiYu.Service.Users.Dto
{
    public class UserDto
    {
        public long Id { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     帐号邮箱
        /// </summary>
        public string AccountEmail { get; set; }

        /// <summary>
        ///     帐号邮箱是否通过验证
        /// </summary>
        public bool IsEmailVerified { get; set; }

        /// <summary>
        ///     手机号码
        /// </summary>
        public string AccountMobile { get; set; }

        /// <summary>
        ///     帐号手机是否通过验证
        /// </summary>
        public bool IsMobileVerified { get; set; }

        /// <summary>
        ///     个人姓名 或 企业名称
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        ///     昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        ///     是否激活
        /// </summary>
        public bool IsActived { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}