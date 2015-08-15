using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.Model.Settings
{
    public class Setting : Entity<string>
    {
        /// <summary>
        ///     设置
        /// </summary>
        public string Settings { get; set; }
    }
}