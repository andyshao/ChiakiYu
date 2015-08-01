using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ChiakiYu.Common.Data
{
    /// <summary>
    ///     用户密码辅助工具类
    /// </summary>
    public class UserPasswordHelper
    {
        /// <summary>
        ///     检查用户密码是否正确
        /// </summary>
        /// <param name="password">用户录入的用户密码（尚未加密的密码）</param>
        /// <param name="storedPassword">数据库存储的密码（即加密过的密码）</param>
        /// <param name="passwordFormat">用户密码存储格式</param>
        public static bool CheckPassword(string password, string storedPassword, UserPasswordFormat passwordFormat)
        {
            var encodedPassword = EncodePassword(password, passwordFormat);

            return encodedPassword != null &&
                   encodedPassword.Equals(storedPassword, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        ///     对用户密码进行编码
        /// </summary>
        /// <param name="password">需要加密的用户密码</param>
        /// <param name="passwordFormat">用户密码存储格式</param>
        public static string EncodePassword(string password, UserPasswordFormat passwordFormat)
        {
            return passwordFormat == UserPasswordFormat.Md5 ? MD5(password) : password;
        }

        #region MD5

        /// <summary>
        ///     标准MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5(string str)
        {
            var b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            return b.Aggregate("", (current, t) => current + t.ToString("x").PadLeft(2, '0'));
        }

        /// <summary>
        ///     16位的MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5_16(string str)
        {
            return MD5(str).Substring(8, 16);
        }

        #endregion

        #region base64编码/解码

        /// <summary>
        ///     base64编码
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string Base64_Encode(string str)
        {
            var encbuff = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encbuff);
        }

        /// <summary>
        ///     base64解码
        /// </summary>
        /// <param name="str">待解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static string Base64_Decode(string str)
        {
            var decbuff = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(decbuff);
        }

        #endregion
    }

    /// <summary>
    ///     用户密码存储格式
    /// </summary>
    public enum UserPasswordFormat
    {
        /// <summary>
        ///     密码未加密
        /// </summary>
        [Display(Name = "不加密")] Clear = 0,

        /// <summary>
        ///     标准MD5加密
        /// </summary>
        [Display(Name = "MD5加密")] Md5 = 1
    }
}