using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using ChiakiYu.Core.Data;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    ///     数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class EntityConfiguration<TEntity, TPrimaryKey> : EntityTypeConfiguration<TEntity>, IEntityMapper
        where TEntity : Entity<TPrimaryKey>
    {
        /// <summary>
        ///     将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="configurations">实体映射配置注册器</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    /// <summary>
    ///     复合数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TComplex">动态复合实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class ComplexConfiguration<TComplex,TPrimaryKey> : ComplexTypeConfiguration<TComplex>, IEntityMapper
        where TComplex : Entity<TPrimaryKey>
    {
        /// <summary>
        ///     将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="configurations">实体映射配置注册器</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}