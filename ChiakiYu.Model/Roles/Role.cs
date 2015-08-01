using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.Model.Roles
{
    /// <summary>
    ///     角色
    /// </summary>
    public class Role : FullEntity<int>
    {
        /// <summary>
        ///     角色名称
        /// </summary>
        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        /// <summary>
        ///     角色显示名称
        /// </summary>
        [Required]
        [StringLength(64)]
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
        ///     基于角色的权限列表
        /// </summary>
        [ForeignKey("RoleId")]
        public virtual ICollection<RolePermission> Permissions { get; set; } //基于角色的权限列表
    }
}