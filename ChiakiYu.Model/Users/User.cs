using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.Common.Data;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.Model.Users
{
    /// <summary>
    ///     用户
    /// </summary>
    public class User : FullEntity<long>
    {
        public User()
        {
            Avatar = "avatar_default";
            IsActived = true;
        }

        #region 需持久化属性

        /// <summary>
        ///     用户名
        /// </summary>
        [Required]
        [StringLength(64)]
        public string UserName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Password { get; set; }

        /// <summary>
        ///     0=Clear（明文）1=标准MD5
        /// </summary>
        public UserPasswordFormat PasswordFormat { get; set; }

        /// <summary>
        ///     帐号邮箱
        /// </summary>
        [StringLength(64)]
        public string AccountEmail { get; set; }

        /// <summary>
        ///     帐号邮箱是否通过验证
        /// </summary>
        public bool IsEmailVerified { get; set; }

        /// <summary>
        ///     手机号码
        /// </summary>
        [StringLength(11)]
        public string AccountMobile { get; set; }

        /// <summary>
        ///     帐号手机是否通过验证
        /// </summary>
        public bool IsMobileVerified { get; set; }

        /// <summary>
        ///     个人姓名 或 企业名称
        /// </summary>
        [StringLength(128)]
        public string TrueName { get; set; }

        /// <summary>
        ///     昵称
        /// </summary>
        [Required]
        [StringLength(64)]
        public string NickName { get; set; }

        /// <summary>
        ///     头像(存储相对路径)
        /// </summary>
        [StringLength(256)]
        public string Avatar { get; set; }

        /// <summary>
        ///     是否激活
        /// </summary>
        public bool IsActived { get; set; }

        #endregion

        [ForeignKey("UserId")]
        public virtual ICollection<UserRole> Roles { get; set; }

        /// <summary>
        ///     基于角色的权限列表
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<UserPermission> Permissions { get; set; } //基于角色的权限列表
    }
}