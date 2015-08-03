using System.ComponentModel.DataAnnotations.Schema;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.Model.Permissions
{
    public class PermissionSite : Entity<int>
    {
        /// <summary>
        /// 父级Id
        /// </summary>
        public int PId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 默认是否打开节点
        /// </summary>
        [NotMapped]
        public bool Open { get; set; }

        /// <summary>
        /// 默认是否选中节点
        /// </summary>
        [NotMapped]
        public bool Checked { get; set; }
    }
}