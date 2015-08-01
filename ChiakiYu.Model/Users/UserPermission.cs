using ChiakiYu.Model.Permissions;

namespace ChiakiYu.Model.Users
{
    /// <summary>
    ///     基于用户的权限
    /// </summary>
    public class UserPermission : Permission
    {
        /// <summary>
        ///     用户Id
        /// </summary>
        public virtual long UserId { get; set; }
    }
}