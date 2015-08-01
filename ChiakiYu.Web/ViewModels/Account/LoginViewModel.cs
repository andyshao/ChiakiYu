using System.ComponentModel.DataAnnotations;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web.ViewModels.Account
{
    /// <summary>
    ///     用于用户登录的view与action中传递参数的实体
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        ///     是否属于模式窗口登录
        /// </summary>
        public bool LoginInModal { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        [Display(Name = "帐号")]
        [Required(ErrorMessage = "请输入用户名/邮箱/手机号")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string PassWord { get; set; }

        /// <summary>
        ///     是否记得密码
        /// </summary>
        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public User AsUser()
        {
            var user = new User
            {
                UserName = UserName,
                Password = PassWord
            };
            return user;
        }
    }
}