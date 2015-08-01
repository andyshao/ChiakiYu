namespace ChiakiYu.Common.Dto
{
    /// <summary>
    ///     分页接口
    /// </summary>
    public interface IPagingDto
    {
        /// <summary>
        ///     页码（当前是第几页）
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        ///     每页数据数
        /// </summary>
        int PageSize { get; set; }

        
    }
}