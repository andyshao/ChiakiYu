namespace ChiakiYu.Core.Data
{
    public interface ISoftDelete
    {
        /// <summary>
        ///     是否删除
        /// </summary>
        bool IsDeleted { get; set; }
    }
}