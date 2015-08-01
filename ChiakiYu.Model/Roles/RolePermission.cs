using ChiakiYu.Model.Permissions;

namespace ChiakiYu.Model.Roles
{
    /// <summary>
    ///     基于角色的权限
    /// </summary>
    public class RolePermission : Permission
    {
        /// <summary>
        ///     角色Id
        /// </summary>
        public virtual int RoleId { get; set; }
    }
}