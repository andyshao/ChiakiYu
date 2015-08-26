namespace ChiakiYu.Core.Data
{
    /// <summary>
    ///     分页数据列表接口
    /// </summary>
    public interface IPagingList : IPaging
    {
        /// <summary>
        ///     总记录数
        /// </summary>
        long TotalCount { get; set; }

        /// <summary>
        ///     总页数
        /// </summary>
        int TotalPages { get; }
    }
}