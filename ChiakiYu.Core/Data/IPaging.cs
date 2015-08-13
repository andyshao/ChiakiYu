namespace ChiakiYu.Core.Data
{
    public interface IPaging
    {
        /// <summary>
        ///     当前页码
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        ///     每页显示记录数
        /// </summary>
        int PageSize { get; set; }
    }
}