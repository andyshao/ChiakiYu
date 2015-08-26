using System;

namespace ChiakiYu.Core.Data
{
    /// <summary>
    ///     分页Dto
    /// </summary>
    [Serializable]
    public class PagingDto : IPaging
    {
        /// <summary>
        ///     当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///     每页显示记录数
        /// </summary>
        public int PageSize { get; set; }
    }
}