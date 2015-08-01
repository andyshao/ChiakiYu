using System.ComponentModel.DataAnnotations;

namespace ChiakiYu.Model.Users
{
   

    /// <summary>
    ///     用户登录状态
    /// </summary>
    public enum UserLoginStatus
    {
        /// <summary>
        ///     通过身份验证
        /// </summary>
        Success = 0,

        /// <summary>
        ///     用户名不存在
        /// </summary>
        IsNotExist = 1,

        /// <summary>
        ///     用户名、密码不匹配
        /// </summary>
        InvalidCredentials = 2,

        /// <summary>
        ///     帐户未激活
        /// </summary>
        NotActivated = 3,

        /// <summary>
        ///     帐户被封禁
        /// </summary>
        Banned = 4,

        /// <summary>
        ///     未知错误
        /// </summary>
        UnknownError = 100
    }
}