﻿using System.Collections.Generic;
using ChiakiYu.Core.Data;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Model.Roles;
using ChiakiYu.Service.Roles.Dto;

namespace ChiakiYu.Service.Roles
{
    /// <summary>
    /// 角色Service接口
    /// </summary>
    public interface IRoleService : IDependency
    {
        /// <summary>
        ///     获取所有角色分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagingList<RoleDto> GetRoles(GetRolesInput input);

        /// <summary>
        ///     获取所有角色列表
        /// </summary>
        /// <returns></returns>
        List<RoleDto> GetRoles();

        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="role">角色实体</param>
        /// <returns></returns>
        Role AddRole(Role role);

        /// <summary>
        ///     获取角色
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        Role GetRole(int roleId);

        /// <summary>
        ///     修改角色
        /// </summary>
        /// <param name="role">角色实体</param>
        /// <returns></returns>
        Role UpdateRole(Role role);
    }
}