using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    ///     数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class EntityConfiguration<TEntity, TPrimaryKey> : EntityTypeConfiguration<TEntity>
        where TEntity : Entity<TPrimaryKey>
    {
    }

    /// <summary>
    ///     复合数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TComplex">动态复合实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class ComplexConfiguration<TComplex, TPrimaryKey> : ComplexTypeConfiguration<TComplex>
        where TComplex : Entity<TPrimaryKey>
    {
    }
}