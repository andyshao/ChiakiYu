using System.Collections.Generic;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Model.Permissions;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Service.Authorization
{
    /// <summary>
    ///     权限业务逻辑
    /// </summary>
    public interface IAuthorizationService : IDependency
    {
        /// <summary>
        ///     创建用户角色
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        string AddUserRole(UserRole userRole);

        /// <summary>
        ///     删除该用户所有角色
        /// </summary>
        /// <param name="userId">用户Id</param>
        void DeleteUserRole(long userId);

        /// <summary>
        ///     删除该角色的所有权限
        /// </summary>
        /// <param name="roleId"></param>
        void DeleteRolePermission(int roleId);

        /// <summary>
        ///     新增角色权限
        /// </summary>
        /// <param name="rolePermission"></param>
        /// <returns></returns>
        string AddRolePermission(RolePermission rolePermission);

        /// <summary>
        ///     获取站点的所有权限
        /// </summary>
        /// <returns></returns>
        List<PermissionSite> GetPermissionAll();
    }
}