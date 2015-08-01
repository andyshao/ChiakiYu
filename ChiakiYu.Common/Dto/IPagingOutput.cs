using System.Collections.Generic;

namespace ChiakiYu.Common.Dto
{
    /// <summary>
    ///     输出分页接口
    /// </summary>
    public interface IPagingOutput : IPagingDto
    {
        long TotalCount { get; set; }

    }
}