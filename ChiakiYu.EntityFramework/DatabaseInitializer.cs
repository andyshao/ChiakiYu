using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using ChiakiYu.EntityFramework.Migrations;

namespace ChiakiYu.EntityFramework
{
    /// <summary>
    ///     数据库初始化操作类
    /// </summary>
    public class DatabaseInitializer
    {
        private static readonly ICollection<Assembly> MapperAssemblies = new List<Assembly>();

        /// <summary>
        ///     获取 数据实体映射配置信息集合
        /// </summary>
        public static ICollection<IEntityMapper> EntityMappers
        {
            get { return GetAllEntityMapper(); }
        }

        /// <summary>
        ///     设置数据库初始化，策略为自动迁移到最新版本
        /// </summary>
        public static void Initialize()
        {
            var context = new CodeFirstDbContext();
            IDatabaseInitializer<CodeFirstDbContext> initializer;
            if (!context.Database.Exists())
            {
                initializer = new CreateDatabaseIfNotExists<CodeFirstDbContext>();
            }
            else
            {
                initializer = new MigrateDatabaseToLatestVersion<CodeFirstDbContext, Configuration>();
            }
            Database.SetInitializer(initializer);

            //EF预热，解决EF6第一次加载慢的问题
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var mappingItemCollection = (StorageMappingItemCollection)objectContext.ObjectStateManager
                .MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            mappingItemCollection.GenerateViews(new List<EdmSchemaError>());
            context.Dispose();
        }

        /// <summary>
        ///     添加需要搜索实体映射的程序集到检索集合中
        /// </summary>
        public static void AddMapperAssembly(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            if (MapperAssemblies.All(m => m != assembly))
            {
                MapperAssemblies.Add(assembly);
            }
        }

        /// <summary>
        /// 获取所有的映射配置类
        /// </summary>
        /// <returns></returns>
        private static ICollection<IEntityMapper> GetAllEntityMapper()
        {
            var baseType = typeof(IEntityMapper);
            var mapperTypes = MapperAssemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(type => baseType.IsAssignableFrom(type) && type != baseType && !type.IsAbstract).ToArray();
            ICollection<IEntityMapper> result =
                mapperTypes.Select(type => Activator.CreateInstance(type) as IEntityMapper).ToList();
            return result;
        }
    }
}