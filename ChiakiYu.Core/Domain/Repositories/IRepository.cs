using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Core.Domain.Entities;
using ChiakiYu.Core.Domain.UnitOfWork;

namespace ChiakiYu.Core.Domain.Repositories
{
    /// <summary>
    ///     实体仓储模型的数据标准操作接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IRepository<T, TKey> : IDependency where T : class, IEntity<TKey>
    {
        #region 属性

        /// <summary>
        ///     获取 当前单元操作对象
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        ///     当前实体类型的查询数据集
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        ///     当前实体类型的查询数据集(不被追踪的)
        /// </summary>
        IQueryable<T> TableNoTracking { get; } 

        #endregion

        #region Get方法

        /// <summary>
        ///     查找指定主键的实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns>符合主键的实体，不存在时返回null</returns>
        T Get(TKey id); 

        #endregion

        #region Insert方法

        /// <summary>
        ///     插入实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        T Insert(T entity);

        /// <summary>
        ///     插入实体（如果存在则更新）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>实体对象</returns>
        T InsertOrUpdate(T entity);

        /// <summary>
        ///     批量插入实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>操作影响的行数</returns>
        int Insert(IEnumerable<T> entities);

        #endregion

        #region Update方法

        /// <summary>
        ///     更新实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>更新后的实体对象</returns>
        T Update(T entity);


        /// <summary>
        ///     更新实体对象集合
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        void Update(IEnumerable<T> entities);

        #endregion

        #region Delete方法

        /// <summary>
        ///     删除实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>成功与否</returns>
        bool Delete(T entity);

        /// <summary>
        ///     删除指定编号的实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>成功与否</returns>
        bool Delete(TKey id);

        /// <summary>
        ///     删除所有符合特定条件的实体
        /// </summary>
        /// <param name="predicate">查询条件谓语表达式</param>
        void Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///     批量删除删除实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        void Delete(IEnumerable<T> entities);

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
        IEnumerable<T> SqlQuery(string sql, bool trackEnabled = true, params object[] parameters);

        #endregion
    }
}