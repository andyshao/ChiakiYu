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
        public static readonly ICollection<Assembly> MapperAssemblies = new List<Assembly>();

        /// <summary>
        ///     设置数据库初始化，策略为自动迁移到最新版本
        /// </summary>
        public static void Initialize()
        {
            var context = new ChiakiYuDbContext();
            IDatabaseInitializer<ChiakiYuDbContext> initializer;
            if (!context.Database.Exists())
            {
                initializer = new CreateDatabaseIfNotExists<ChiakiYuDbContext>();
            }
            else
            {
                initializer = new MigrateDatabaseToLatestVersion<ChiakiYuDbContext, Configuration>();
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
        ///     添加需要搜索实体映射的程序集到集合中
        /// </summary>
        public static void AddMapperAssembly(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            if (MapperAssemblies.All(m => m != assembly))
            {
                MapperAssemblies.Add(assembly);
            }
        }
    }
}