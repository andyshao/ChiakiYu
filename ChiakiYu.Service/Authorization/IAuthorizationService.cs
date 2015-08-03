using System.Collections.Generic;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Model.Permissions;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Authorization.Dto;

namespace ChiakiYu.Service.Authorization
{
    public interface IAuthorizationService : IDependency 
    {
        /// <summary>
        ///     获取用户角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        List<UserRole> GetUserRoles(GetUserRolesInput input);

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

        void DeleteRolePermission(int roleId);

        string AddRolePermission(RolePermission rolePermission);

        List<RolePermission> GetRolePermissions(string name, int roleId);


        List<PermissionSite> GetPermissionAll();
    }
}