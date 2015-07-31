using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Core.Domain.UnitOfWork;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    ///     EntityFramework-CodeFirst数据上下文
    /// </summary>
    public class ChiakiYuDbContext : DbContext, IUnitOfWork, IDependency
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        public ChiakiYuDbContext()
            : this(GetConnectionStringName())
        {
        }

        /// <summary>
        ///     使用连接名称或连接字符串
        /// </summary>
        public ChiakiYuDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public bool TransactionEnabled { get; set; }

        /// <summary>
        ///     获取 数据库连接串名称
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionStringName()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString ?? "Default";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //注册实体配置信息
            var assemblys = DatabaseInitializer.MapperAssemblies;
            foreach (var assembly in assemblys)
            {
                modelBuilder.Configurations.AddFromAssembly(assembly);
            }
        }
    }
}