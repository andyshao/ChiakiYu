using System.Collections.Generic;
using System.Linq;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Permissions;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Service.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRepository<PermissionSite, int> _permissionAllRepository;
        private readonly IRepository<RolePermission, string> _rolePermissionRepository;
        private readonly IRepository<UserPermission, string> _userPermissionRepository;
        private readonly IRepository<UserRole, string> _userRoleRepository;

        public AuthorizationService
            (IRepository<UserRole, string> userRoleRepository,
                IRepository<RolePermission, string> rolePermissionRepository,
                IRepository<UserPermission, string> userPermissionRepository,
                IRepository<PermissionSite, int> permissionAllRepository)
        {
            _userRoleRepository = userRoleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _userPermissionRepository = userPermissionRepository;
            _permissionAllRepository = permissionAllRepository;
        }

        /// <summary>
        ///     创建用户角色
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        public string AddUserRole(UserRole userRole)
        {
            return _userRoleRepository.Insert(userRole).Id;
        }

        /// <summary>
        ///     删除该用户所有角色
        /// </summary>
        /// <param name="userId">用户Id</param>
        public void DeleteUserRole(long userId)
        {
            _userRoleRepository.Delete(n => n.UserId == userId);
        }

        /// <summary>
        ///     删除该角色的所有权限
        /// </summary>
        /// <param name="roleId"></param>
        public void DeleteRolePermission(int roleId)
        {
            _rolePermissionRepository.Delete(n => n.RoleId == roleId);
        }

        /// <summary>
        ///     新增角色权限
        /// </summary>
        /// <param name="rolePermission"></param>
        /// <returns></returns>
        public string AddRolePermission(RolePermission rolePermission)
        {
            return _rolePermissionRepository.Insert(rolePermission).Id;
        }

        /// <summary>
        ///     获取站点的所有权限
        /// </summary>
        /// <returns></returns>
        public List<PermissionSite> GetPermissionAll()
        {
            var query = _permissionAllRepository.Table;
            return query.ToList();
        }
    }
}