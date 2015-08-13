using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChiakiYu.Core.Data
{
    /// <summary>
    ///     分页数据封装
    /// </summary>
    /// <typeparam name="TEntity">分页数据的实体类型</typeparam>
    [Serializable]
    public class PagingList<TEntity> : ReadOnlyCollection<TEntity>, IPagingList
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="source">分页数据的实体集合</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalCount">总记录数</param>
        public PagingList(IQueryable<TEntity> source, int pageIndex, int pageSize, long totalCount)
            : base(source.ToList())
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="source">分页数据的实体集合</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalCount">总记录数</param>
        public PagingList(IList<TEntity> source, int pageIndex, int pageSize, long totalCount)
            : base(source)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="source">分页数据的实体集合</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalCount">总记录数</param>
        public PagingList(IEnumerable<TEntity> source, int pageIndex, int pageSize, long totalCount)
            : base(source.ToList())
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

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

        /// <summary>
        ///     总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                var result = TotalCount / PageSize;
                if (TotalCount % PageSize > 0)
                    result++;

                return Convert.ToInt32(result);
            }
        }
    }
}