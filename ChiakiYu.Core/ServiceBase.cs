using ChiakiYu.Core.Domain.UnitOfWork;

namespace ChiakiYu.Core
{
    /// <summary>
    /// 业务实现基类
    /// </summary>
    public abstract class ServiceBase
    {
        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取或设置 单元操作对象
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; private set; }
    }
}