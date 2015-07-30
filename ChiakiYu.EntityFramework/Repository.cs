using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ChiakiYu.Core.Data;

namespace ChiakiYu.EntityFramework
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public IQueryable<TEntity> Entities { get; private set; }

        public int Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TPrimaryKey key)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TPrimaryKey key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetInclude<TProperty>(Expression<Func<TEntity, TProperty>> path)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetIncludes(params string[] paths)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> SqlQuery(string sql, bool trackEnabled = true, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TPrimaryKey key)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckExistsAsync(Expression<Func<TEntity, bool>> predicate,
            TPrimaryKey id = default(TPrimaryKey))
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByKeyAsync(TPrimaryKey key)
        {
            throw new NotImplementedException();
        }
    }
}