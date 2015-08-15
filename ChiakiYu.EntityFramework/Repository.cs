using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ChiakiYu.Core.Domain.Entities;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Core.Domain.UnitOfWork;

namespace ChiakiYu.EntityFramework
{
    public class Repository<T, TKey> : IRepository<T, TKey>
        where T : class, IEntity<TKey>
    {
        private readonly DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        #region 构造函数
        /// <summary>
        ///     构造函数
        /// </summary>
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = ((DbContext)unitOfWork).Set<T>();
        }
        #endregion

        #region 属性

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public IQueryable<T> Table
        {
            get { return _dbSet; }
        }

        public IQueryable<T> TableNoTracking
        {
            get { return _dbSet.AsNoTracking(); }
        }
        #endregion

        #region Get方法
        public T Get(TKey id)
        {
            return _dbSet.Find(id);
        }
        #endregion

        #region Insert方法

        public T Insert(T entity)
        {
            _dbSet.Add(entity);
            return SaveChanges() > 0 ? entity : null;
        }

        public T InsertOrUpdate(T entity)
        {

            //return EqualityComparer<TKey>.Default.Equals(entity.Id, default(TKey))
            return Get(entity.Id) == null
            ? Insert(entity)
            : Update(entity);
        }

        public int Insert(IEnumerable<T> entities)
        {
            entities = entities as T[] ?? entities.ToArray();
            _dbSet.AddRange(entities);
            return SaveChanges();
        }

        #endregion

        #region Update方法

        public T Update(T entity)
        {
            var entityUpdate = ((DbContext)_unitOfWork).Update<T, TKey>(entity);
            return SaveChanges() > 0 ? entityUpdate : null;
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                ((DbContext)_unitOfWork).Update<T, TKey>(entity);
            }
            SaveChanges();
        }

        #endregion

        #region Delete方法

        public bool Delete(T entity)
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

        public bool Delete(TKey id)
        {
            var entity = _dbSet.Find(id);
            return entity != null && Delete(entity);
        }


        public void Delete(Expression<Func<T, bool>> predicate)
        {
            foreach (var entity in Table.Where(predicate).ToList())
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
            }
            SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
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
            }
            SaveChanges();
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
        public IEnumerable<T> SqlQuery(string sql, bool trackEnabled = true, params object[] parameters)
        {
            return trackEnabled
                ? _dbSet.SqlQuery(sql, parameters)
                : _dbSet.SqlQuery(sql, parameters).AsNoTracking();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 提交更改
        /// </summary>
        /// <returns></returns>
        private int SaveChanges()
        {
            return _unitOfWork.TransactionEnabled ? 0 : _unitOfWork.SaveChanges();
        }

        #endregion
    }
}