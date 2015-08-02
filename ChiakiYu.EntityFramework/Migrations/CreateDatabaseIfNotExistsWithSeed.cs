using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ChiakiYu.EntityFramework.Migrations
{
    /// <summary>
    ///     在数据库不存在时使用种子数据创建数据库
    /// </summary>
    public class CreateDatabaseIfNotExistsWithSeed : CreateDatabaseIfNotExists<ChiakiYuDbContext>
    {
        static CreateDatabaseIfNotExistsWithSeed()
        {
            SeedActions = new List<ISeedAction>();
        }

        /// <summary>
        ///     获取 数据库创建时的种子数据操作信息集合，各个模块可以添加自己的初始化数据
        /// </summary>
        public static ICollection<ISeedAction> SeedActions { get; private set; }

        protected override void Seed(ChiakiYuDbContext context)
        {
            IEnumerable<ISeedAction> seedActions = SeedActions.OrderBy(m => m.Order);
            foreach (var seedAction in seedActions)
            {
                seedAction.Action(context);
            }
        }
    }
}