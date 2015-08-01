using System;
using System.Collections.Generic;

namespace ChiakiYu.Common.Dto
{
    /// <summary>
    ///     分页输出
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingOutput<T> : IPagingOutput
    {
        /// <summary>
        ///     页数（自动计算）
        /// </summary>
        public int PageCount
        {
            get
            {
                var result = TotalCount / PageSize;
                if (TotalCount % PageSize != 0)
                    result++;

                return Convert.ToInt32(result);
            }
        }

        /// <summary>
        ///     数据集合
        /// </summary>
        public IReadOnlyList<T> Items { get; set; }

        /// <summary>
        ///     当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///     每页显示记录数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     总记录数
        /// </summary>
        public long TotalCount { get; set; }
    }
}