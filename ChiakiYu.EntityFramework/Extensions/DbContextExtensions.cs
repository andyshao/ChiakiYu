using System;
using System.Data.Entity;
using ChiakiYu.Core.Domain.Entities;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    ///     上下文扩展辅助操作类
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        ///     更新上下文中指定的实体的状态
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TPrimaryKey">主键类型</typeparam>
        /// <param name="dbContext">上下文对象</param>
        /// <param name="entity">要更新的实体类型</param>
        public static TEntity Update<TEntity, TPrimaryKey>(this DbContext dbContext, TEntity entity)
            where TEntity : class, IEntity<TPrimaryKey>
        {
            var dbSet = dbContext.Set<TEntity>();
            try
            {
                var entry = dbContext.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                    entry.State = EntityState.Modified;
                }
                return entity;
            }
            catch (InvalidOperationException)
            {
                var oldEntity = dbSet.Find(entity.Id);
                dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
                return oldEntity;
            }
        }
    }
}