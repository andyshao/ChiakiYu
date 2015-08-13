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
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role, int> _roleRepository;

        public RoleService(IRepository<Role, int> roleRepository)
        {
            _roleRepository = roleRepository;
        }

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

        List<RoleDto> IRoleService.GetRoles()
        {
            var query = _roleRepository.Table;
            return query.MapTo<List<RoleDto>>();
        }

        public Role AddRole(Role role)
        {
            return _roleRepository.Insert(role);
        }

        public Role GetRole(int roleId)
        {
            var role = _roleRepository
                .Table
                .Include(p => p.Permissions)
                .FirstOrDefault(q => q.Id == roleId);
            return role;
        }

        public Role UpdateRole(Role role)
        {
            return _roleRepository.Update(role);
        }
    }
}