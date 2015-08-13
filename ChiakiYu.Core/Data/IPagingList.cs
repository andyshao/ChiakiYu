namespace ChiakiYu.Core.Data
{
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