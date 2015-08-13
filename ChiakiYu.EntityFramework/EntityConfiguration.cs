using System.Data.Entity.ModelConfiguration;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    ///     数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public abstract class EntityConfiguration<TEntity, TKey> : EntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity<TKey>
    {
    }

    /// <summary>
    ///     复合数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TComplex">动态复合实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public abstract class ComplexConfiguration<TComplex, TKey> : ComplexTypeConfiguration<TComplex>
        where TComplex : class, IEntity<TKey>
    {
    }
}