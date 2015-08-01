using System;
using System.Collections.Generic;
using ChiakiYu.Model.Roles;

namespace ChiakiYu.Service.Roles.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }

        /// <summary>
        ///     角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     角色显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///     是否 不可删除
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        ///     是否是默认角色
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        public List<RolePermission> Permissions { get; set; }
    }
}