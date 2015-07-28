using System.Data.Entity;
using ChiakiYu.Core.Data;
using ChiakiYu.Core.Dependency;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    /// EntityFramework-CodeFirst数据上下文
    /// </summary>
    public class CodeFirstDbContext : DbContext, IUnitOfWork, IDependency
    {
         
    }
}