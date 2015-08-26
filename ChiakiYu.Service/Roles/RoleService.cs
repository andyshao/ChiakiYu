using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ChiakiYu.Core.AutoMapper;
using ChiakiYu.Core.Data;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Roles;
using ChiakiYu.Service.Roles.Dto;

namespace ChiakiYu.Service.Roles
{
    /// <summary>
    /// 角色Service
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role, int> _roleRepository;

        public RoleService(IRepository<Role, int> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        /// <summary>
        ///     获取所有角色分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingList<RoleDto> GetRoles(GetRolesInput input)
        {
            var query = _roleRepository.Table;
            var source = query.OrderBy(n => n.Id)
                .Skip((input.PageIndex - 1) * input.PageSize)
                .Take(input.PageSize)
                .MapTo<List<RoleDto>>();
            var result = new PagingList<RoleDto>(source, input.PageIndex, input.PageSize, query.LongCount());
            return result;
        }

        /// <summary>
        ///     获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<RoleDto> GetRoles()
        {
            var query = _roleRepository.Table;
            return query.MapTo<List<RoleDto>>();
        }

        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="role">角色实体</param>
        /// <returns></returns>
        public Role AddRole(Role role)
        {
            return _roleRepository.Insert(role);
        }

        /// <summary>
        ///     获取角色
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public Role GetRole(int roleId)
        {
            var role = _roleRepository
                .Table
                .Include(p => p.Permissions)
                .FirstOrDefault(q => q.Id == roleId);
            return role;
        }

        /// <summary>
        ///     修改角色
        /// </summary>
        /// <param name="role">角色实体</param>
        /// <returns></returns>
        public Role UpdateRole(Role role)
        {
            return _roleRepository.Update(role);
        }
    }
}