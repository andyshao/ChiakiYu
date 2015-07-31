using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ChiakiYu.Core.Dependency;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    ///     EntityFramework-CodeFirst数据上下文
    /// </summary>
    public class ChiakiYuDbContext : DbContext, IDependency
    {
        public ChiakiYuDbContext()
            : base("Default")
        {
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