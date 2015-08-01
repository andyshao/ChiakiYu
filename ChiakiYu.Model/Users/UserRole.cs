using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.Model.Users
{
    /// <summary>
    ///     用户角色
    /// </summary>
    public class UserRole : FullEntity<string>
    {
        public UserRole()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public UserRole(long userId, int roleId)
        {
            Id = Guid.NewGuid().ToString("N");
            UserId = userId;
            RoleId = roleId;
        }

        [StringLength(32)]
        public override string Id { get; set; }

        /// <summary>
        ///     用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///     角色Id
        /// </summary>
        public int RoleId { get; set; }
    }
}