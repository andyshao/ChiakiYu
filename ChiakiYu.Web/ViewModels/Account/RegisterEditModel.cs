using System.ComponentModel.DataAnnotations;
using ChiakiYu.Common.Data;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web.ViewModels.Account
{
    public class RegisterEditModel
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
        ///     密码
        /// </summary>
        [Display(Name = "密码")]
        [StringLength(18, ErrorMessage = "密码最多允许输入18个字符")]
        [Required(ErrorMessage = "请输入密码")]
        public string PassWord { get; set; }

        /// <summary>
        ///     确认密码
        /// </summary>
        [Display(Name = "确认密码")]
        [Compare("PassWord", ErrorMessage = "确认密码与密码不符")] //设置确认密码是否与密码相同
        public string ConfirmPassWord { get; set; }

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

        /// <summary>
        ///     接受条款
        /// </summary>
        [Display(Name = "我已看过并完全同意")]
        public bool AcceptableProvision { get; set; }

        public User AsUser()
        {
            var user = new User
            {
                UserName = UserName,
                PasswordFormat = UserPasswordFormat.Md5,
                Password = UserPasswordHelper.EncodePassword(PassWord, UserPasswordFormat.Md5),
                AccountEmail = AccountEmail,
                AccountMobile = AccountMobile,
                NickName = NickName
            };
            return user;
        }
    }
}