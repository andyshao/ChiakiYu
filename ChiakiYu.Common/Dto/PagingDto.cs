using System;

namespace ChiakiYu.Common.Dto
{
    /// <summary>
    ///     分页基类
    /// </summary>
    [Serializable]
    public class PagingDto : IPagingDto
    {
        /// <summary>
        ///     页码（当前是第几页）
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///     每页数据数
        /// </summary>
        public int PageSize { get; set; }
    }
}