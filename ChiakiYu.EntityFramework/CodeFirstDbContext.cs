using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Model.Users;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    ///     EntityFramework-CodeFirst数据上下文
    /// </summary>
    public class CodeFirstDbContext : DbContext, IDependency
    {
        public CodeFirstDbContext()
            : base("Default")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //注册实体配置信息
            var entityMappers = DatabaseInitializer.EntityMappers;
            foreach (var mapper in entityMappers)
            {
                mapper.RegistTo(modelBuilder.Configurations);
            }
        }
    }
}