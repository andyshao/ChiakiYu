using System.Data.Entity.Migrations;

namespace ChiakiYu.EntityFramework.Migrations
{
    /// <summary>
    /// Ĭ��Ǩ������
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ChiakiYuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// ��ȡ ����Ǩ�Ƴ�ʼ���������ݲ�����Ϣ���ϣ�����ģ���������Լ������ݳ�ʼ������
        /// </summary>
        protected override void Seed(ChiakiYuDbContext context)
        {


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}