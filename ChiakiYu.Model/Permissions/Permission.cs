using System;
using System.ComponentModel.DataAnnotations;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.Model.Permissions
{
    /// <summary>
    ///     权限
    /// </summary>
    public class Permission : Entity<string>
    {
        public Permission()
        {
            Id = Guid.NewGuid().ToString("N");
            IsGranted = true;
        }

        [StringLength(32)]
        public override string Id { get; set; }

        /// <summary>
        ///     权限名称
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        ///     是否通过验证
        /// </summary>
        public bool IsGranted { get; set; }
    }
}