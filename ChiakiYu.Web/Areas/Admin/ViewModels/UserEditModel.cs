using System.ComponentModel.DataAnnotations;
using ChiakiYu.Common.Data;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web.Areas.Admin.ViewModels
{
    public class UserEditModel
    {
        /// <summary>
        ///     用户名
        /// </summary>
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Display(Name = "昵称")]
        [Required(ErrorMessage = "请输入昵称")]
        [DataType(DataType.Text)]
        public string NickName { get; set; }

        /// <summary>
        ///     帐号邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "请输入邮箱")]
        [StringLength(50, ErrorMessage = "邮箱最多允许输入50个字符")]
        public string AccountEmail { get; set; }

        /// <summary>
        ///     帐号手机
        /// </summary>
        [Display(Name = "手机号")]
        [Required(ErrorMessage = "请输入手机号")]
        [StringLength(11, ErrorMessage = "手机号最多允许输入11个数字")]
        public string AccountMobile { get; set; }

        public User AsUser()
        {
            var user = new User
            {
                UserName = UserName,
                NickName = NickName,
                PasswordFormat = UserPasswordFormat.Md5,
                Password = UserPasswordHelper.EncodePassword("123456", UserPasswordFormat.Md5),
                AccountEmail = AccountEmail,
                AccountMobile = AccountMobile
            };
            return user;
        }
    }
}