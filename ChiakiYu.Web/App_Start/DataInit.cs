using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using ChiakiYu.EntityFramework.Migrations;
using ChiakiYu.Model.Navigations;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web
{
    public class DataInit : ISeedAction
    {
        /// <summary>
        /// 获取 操作排序，数值越小越先执行
        /// </summary>
        public int Order { get { return 0; } }

        /// <summary>
        /// 定义种子数据初始化过程
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void Action(DbContext context)
        {
            var userList = new List<User>
            {
                new User()
                {
                    UserName = "admin",
                    Password = "e10adc3949ba59abbe56e057f20f883e",
                    PasswordFormat = Common.Data.UserPasswordFormat.Md5,
                    AccountEmail = "yu_199012@qq.com",
                    IsEmailVerified = true,
                    AccountMobile = "15265627570",
                    IsMobileVerified = true,
                    TrueName = "于琦",
                    NickName = "超级管理员",
                    IsActived = true

                }
            };
            context.Set<User>().AddOrUpdate(m => new { m.UserName, m.AccountEmail, m.AccountMobile }, userList.ToArray());


            //var roleList = new List<Role>
            //{
            //     new Role(){Id=1001000,Name = "首页",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = "/Home",IconName = "fa fa-home",Order = 1,IsEnabled = true}
            //};
            //context.Set<Role>().AddOrUpdate(m => new { m.Name }, roleList.ToArray());


            var navigationList = new List<Navigation>
            {
                 new Navigation(){Id=1001000,Name = "首页",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "/Home",IconName = "fa fa-home",Order = 1,IsEnabled = true}
                ,new Navigation(){Id=1002000,Name = "关于",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "/About",IconName = null,Order = 2,IsEnabled = true}
                ,new Navigation(){Id=1003000,Name = "更多",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "/More",IconName = "fa fa-chevron-circle-down",Order = 3,IsEnabled = true}
                ,new Navigation(){Id=1003001,Name = "新闻详情",PresentArea = PresentArea.Channel,Level = 1,ParentId = 1003000,Url = "/NewsDetail",IconName = null,Order = 4,IsEnabled = true}
                ,new Navigation(){Id=1004000,Name = "新闻",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "/News",IconName = null,Order = 5,IsEnabled = true}
                ,new Navigation(){Id=1005000,Name = "服务",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "/Portfolio",IconName = null,Order = 6,IsEnabled = true}
                                  
                ,new Navigation(){Id=2001000,Name = "首页",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = "/Admin/Home",IconName = "fa fa-home fa-fw",Order = 1,IsEnabled = true}
                ,new Navigation(){Id=2002000,Name = "用户",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = null,IconName = "fa fa-users fa-fw",Order = 2,IsEnabled = true}
                ,new Navigation(){Id=2002001,Name = "用户管理",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2002000,Url = "/AdminUser/ManageUsers",IconName = null,Order = 3,IsEnabled = true}
                ,new Navigation(){Id=2002002,Name = "角色管理",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2002000,Url = "/AdminUser/ManageRoles",IconName = null,Order = 4,IsEnabled = true}
                ,new Navigation(){Id=2003000,Name = "新闻",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = null,IconName = "fa fa-newspaper-o fa-fw",Order = 5,IsEnabled = true}
                ,new Navigation(){Id=2003001,Name = "新闻管理",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2003000,Url = null,IconName = null,Order = 6,IsEnabled = true}
                ,new Navigation(){Id=2003002,Name = "新闻类别",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2003000,Url = null,IconName = null,Order = 7,IsEnabled = true}
                ,new Navigation(){Id=2003003,Name = "发布新闻",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2003000,Url =null,IconName = null,Order = 8,IsEnabled = true}
                ,new Navigation(){Id=2004000,Name = "系统",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = null,IconName = "fa fa-cogs fa-fw",Order = 9,IsEnabled = true}
                ,new Navigation(){Id=2004001,Name = "站点管理",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2004000,Url = null,IconName =null,Order = 10,IsEnabled = true}
                ,new Navigation(){Id=2004002,Name = "重启站点",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2004000,Url = null,IconName = null,Order = 11,IsEnabled = true}
                ,new Navigation(){Id=2004003,Name = "清理缓存",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2004000,Url = null,IconName = null,Order = 12,IsEnabled = true}
            };
            context.Set<Navigation>().AddOrUpdate(m => new { m.Name }, navigationList.ToArray());


        }
    }
}