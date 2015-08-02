using System.Collections.Generic;
using System.Linq;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Permissions;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Authorization.Dto;

namespace ChiakiYu.Service.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRepository<RolePermission, string> _rolePermissionRepository;
        private readonly IRepository<UserPermission, string> _userPermissionRepository;
        private readonly IRepository<UserRole, string> _userRoleRepository;

        private readonly IRepository<PermissionAll, int> _permissionAllRepository;

        public AuthorizationService
            (IRepository<UserRole, string> userRoleRepository,
                IRepository<RolePermission, string> rolePermissionRepository,
                IRepository<UserPermission, string> userPermissionRepository,
                IRepository<PermissionAll, int> permissionAllRepository)
        {
            _userRoleRepository = userRoleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _userPermissionRepository = userPermissionRepository;
            _permissionAllRepository = permissionAllRepository;
        }

        public List<PermissionAll> GetPermissionAll()
        {
            var query = _permissionAllRepository.GetAll();
            return query.ToList();
        }

        public List<UserRole> GetUserRoles(GetUserRolesInput input)
        {
            var query = _userRoleRepository.GetAll().Where(n => n.UserId == input.UserId);
            return query.ToList();
        }

        public string AddUserRole(UserRole userRole)
        {
            return _userRoleRepository.Insert(userRole).Id;
        }

        public void DeleteUserRole(long userId)
        {
            _userRoleRepository.Delete(n => n.UserId == userId);
        }

        public void DeleteRolePermission(int roleId)
        {
            _rolePermissionRepository.Delete(n => n.RoleId == roleId);
        }

        public string AddRolePermission(RolePermission rolePermission)
        {
            return _rolePermissionRepository.Insert(rolePermission).Id;
        }

        public List<RolePermission> GetRolePermissions(string name, int roleId)
        {
            var query =
                _rolePermissionRepository.GetAll()
                    .Where(n => n.RoleId == roleId && n.Name.Contains(name) && n.Name.Length == name.Length + 5);
            return query.ToList();
        }


    }
}