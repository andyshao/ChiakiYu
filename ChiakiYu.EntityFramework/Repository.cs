using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ChiakiYu.Core.Domain.Entities;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Core.Domain.UnitOfWork;

namespace ChiakiYu.EntityFramework
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     构造函数
        /// </summary>
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = ((DbContext)unitOfWork).Set<TEntity>();
        }

        /// <summary>
        ///     获取 当前单元操作对象
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        #region Get&Gets

        /// <summary>
        ///     获取 当前实体类型的查询数据集
        /// </summary>
        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        ///     查找指定主键的实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns>符合主键的实体，不存在时返回null</returns>
        public TEntity Get(TPrimaryKey id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// 异步查找指定主键的实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns>符合主键的实体，不存在时返回null</returns>
        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        #endregion

        #region Insert

        public TEntity Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            return SaveChanges() > 0 ? entity : null;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await SaveChangesAsync() > 0 ? entity : null;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            return EqualityComparer<TPrimaryKey>.Default.Equals(entity.Id, default(TPrimaryKey))
                ? Insert(entity)
                : Update(entity);
        }

        public async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return EqualityComparer<TPrimaryKey>.Default.Equals(entity.Id, default(TPrimaryKey))
                ? await InsertAsync(entity)
                : await UpdateAsync(entity);
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            entities = entities as TEntity[] ?? entities.ToArray();
            _dbSet.AddRange(entities);
            return SaveChanges();
        }

        public async Task<int> InsertAsync(IEnumerable<TEntity> entities)
        {
            entities = entities as TEntity[] ?? entities.ToArray();
            _dbSet.AddRange(entities);
            return await SaveChangesAsync();
        }

        #endregion

        #region Update

        public TEntity Update(TEntity entity)
        {
            //todo:需要处理失败之后怎么通知调用层
            var entityUpdate = ((DbContext)_unitOfWork).Update<TEntity, TPrimaryKey>(entity);
            return SaveChanges() > 0 ? entityUpdate : null;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            //todo:需要处理失败之后怎么通知调用层
            var entityUpdate = ((DbContext)_unitOfWork).Update<TEntity, TPrimaryKey>(entity);
            return await SaveChangesAsync() > 0 ? entityUpdate : null;
        }

        #endregion

        #region Delete

        public bool Delete(TEntity entity)
        {
            if (entity is ISoftDelete)
            {
                (entity as ISoftDelete).IsDeleted = true;
                (entity as ISoftDelete).DeletedTime = DateTime.Now;
            }
            else
            {
                _dbSet.Remove(entity);
            }
            return SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            if (entity is ISoftDelete)
            {
                (entity as ISoftDelete).IsDeleted = true;
                (entity as ISoftDelete).DeletedTime = DateTime.Now;
            }
            else
            {
                _dbSet.Remove(entity);
            }
            return await SaveChangesAsync() > 0;
        }

        public bool Delete(TPrimaryKey id)
        {
            var entity = _dbSet.Find(id);
            return entity != null && Delete(entity);
        }

        public async Task<bool> DeleteAsync(TPrimaryKey id)
        {
            var entity = _dbSet.Find(id);
            return entity != null && await DeleteAsync(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                await DeleteAsync(entity);
            }
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await DeleteAsync(entity);
            }
        }

        #endregion

        #region 创建一个原始 SQL 查询，该查询将返回此集中的实体

        /// <summary>
        ///     创建一个原始 SQL 查询，该查询将返回此集中的实体。
        ///     默认情况下，上下文会跟踪返回的实体；可通过对返回的 DbRawSqlQuery 调用 AsNoTracking 来更改此设置。 请注意返回实体的类型始终是此集的类型，而不会是派生的类型。
        ///     如果查询的一个或多个表可能包含其他实体类型的数据，则必须编写适当的 SQL 查询以确保只返回适当类型的实体。 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 您可以在 SQL
        ///     查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 您提供的任何参数值都将自动转换为 DbParameter。 context.Set(typeof(Blog)).SqlQuery("SELECT * FROM
        ///     dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL
        ///     查询字符串中使用命名参数。 context.Set(typeof(Blog)).SqlQuery("SELECT * FROM dbo.Posts WHERE Author = @author", new
        ///     SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <param name="trackEnabled">是否跟踪返回实体</param>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">
        ///     要应用于 SQL 查询字符串的参数。 如果使用输出参数，则它们的值在完全读取结果之前不可用。 这是由于 DbDataReader 的基础行为而导致的，有关详细信息，请参见
        ///     http://go.microsoft.com/fwlink/?LinkID=398589。
        /// </param>
        /// <returns></returns>
        public IEnumerable<TEntity> SqlQuery(string sql, bool trackEnabled = true, params object[] parameters)
        {
            return trackEnabled
                ? _dbSet.SqlQuery(sql, parameters)
                : _dbSet.SqlQuery(sql, parameters).AsNoTracking();
        }

        #endregion

        #region 私有方法

        private int SaveChanges()
        {
            return _unitOfWork.TransactionEnabled ? 0 : _unitOfWork.SaveChanges();
        }

        private async Task<int> SaveChangesAsync()
        {
            return _unitOfWork.TransactionEnabled ? 0 : await _unitOfWork.SaveChangesAsync();
        }

        #endregion
    }
}