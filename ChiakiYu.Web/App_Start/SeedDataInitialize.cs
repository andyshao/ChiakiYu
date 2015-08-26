using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using ChiakiYu.Common.Data;
using ChiakiYu.EntityFramework.Migrations;
using ChiakiYu.Model.Navigations;
using ChiakiYu.Model.Permissions;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web
{
    /// <summary>
    /// 种子数据初始化
    /// </summary>
    public class SeedDataInitialize : ISeedAction
    {
        /// <summary>
        ///     获取 操作排序，数值越小越先执行
        /// </summary>
        public int Order
        {
            get { return 0; }
        }

        /// <summary>
        ///     定义种子数据初始化过程
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void Action(DbContext context)
        {
            #region 导航

            var navigationList = new List<Navigation>
            {
                 new Navigation{Id = 1001000,Name = "首页",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "/",IconName = "fa fa-home",Order = 1001000,IsEnabled = true}
                ,new Navigation{Id = 1002000,Name = "关于",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "/About",IconName = null,Order = 1002000,IsEnabled = true}
                ,new Navigation{Id = 1003000,Name = "日志",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "/Blog",IconName = null,Order = 1003000,IsEnabled = true}
                ,new Navigation{Id = 1004000,Name = "更多",PresentArea = PresentArea.Channel,Level = 1,ParentId = 0,Url = "",IconName = "fa fa-chevron-circle-down",Order =1004000,IsEnabled = true}
                ,new Navigation{Id = 1004001,Name = "即时通讯",PresentArea = PresentArea.Channel,Level = 1,ParentId = 1004000,Url = "/Chat",IconName = null,Order =1004001,IsEnabled = true}
                ,new Navigation{Id = 1004002,Name = "倒计时",PresentArea = PresentArea.Channel,Level = 1,ParentId = 1004000,Url = "/ComingSoon",IconName = null,Order = 1004002,IsEnabled = true}
                
                ,new Navigation{Id = 2001000,Name = "首页",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = "/Admin/Home",IconName = "fa fa-home fa-fw",Order = 2001000,IsEnabled = true}
                ,new Navigation{Id = 2002000,Name = "用户",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = null,IconName = "fa fa-users fa-fw",Order = 2002000,IsEnabled = true}
                ,new Navigation{Id = 2002001,Name = "用户管理",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2002000,Url = "/AdminUser/ManageUsers",IconName = null,Order = 2002001,IsEnabled = true}
                ,new Navigation{Id = 2002002,Name = "角色管理",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2002000,Url = "/AdminUser/ManageRoles",IconName = null,Order = 2002002,IsEnabled = true}
                ,new Navigation{Id = 2003000,Name = "日志",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = null,IconName = "fa fa-newspaper-o fa-fw",Order = 2003000,IsEnabled = true}
                ,new Navigation{Id = 2003001,Name = "日志管理",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2003000,Url = null,IconName = null,Order = 2003001,IsEnabled = true}
                ,new Navigation{Id = 2003002,Name = "日志类别",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2003000,Url = null,IconName = null,Order = 2003002,IsEnabled = true}
                ,new Navigation{Id = 2003003,Name = "发表日志",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2003000,Url = null,IconName = null,Order = 2003003,IsEnabled = true}
                ,new Navigation{Id = 2004000,Name = "系统",PresentArea = PresentArea.Admin,Level = 1,ParentId = 0,Url = null,IconName = "fa fa-cogs fa-fw",Order = 2004000,IsEnabled = true}
                ,new Navigation{Id = 2004001,Name = "站点设置",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2004000,Url = "/AdminSetting/SiteSettings",IconName = null,Order = 2004001,IsEnabled = true}
                ,new Navigation{Id = 2004002,Name = "重启站点",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2004000,Url = null,IconName = null,Order = 2004002,IsEnabled = true}
                ,new Navigation{Id = 2004003,Name = "清理缓存",PresentArea = PresentArea.Admin,Level = 2,ParentId = 2004000,Url = null,IconName = null,Order = 2004003,IsEnabled = true}
            };
            context.Set<Navigation>().AddOrUpdate(m => new { m.Name }, navigationList.ToArray());

            #endregion

            #region 用户

            var userList = new List<User>
            {
                new User
                {
                    UserName = "admin",
                    Password = "e10adc3949ba59abbe56e057f20f883e",
                    PasswordFormat = UserPasswordFormat.Md5,
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

            #endregion

            #region 角色

            var roleList = new List<Role>
            {
                new Role {Name = "SuperAdministrator", DisplayName = "超级管理员", IsStatic = true, IsDefault = false}
                ,
                new Role {Name = "SysAdministrator", DisplayName = "系统管理员", IsStatic = true, IsDefault = false}
                ,
                new Role {Name = "User", DisplayName = "普通用户", IsStatic = true, IsDefault = true}
            };
            context.Set<Role>().AddOrUpdate(m => new { m.Name }, roleList.ToArray());

            #endregion

            #region 用户角色

            var userRoleList = new List<UserRole>
            {
                new UserRole(1, 1)
            };
            context.Set<UserRole>().AddOrUpdate(userRoleList.ToArray());

            #endregion

            #region 权限

            var permissionAll = new List<PermissionSite>
            {
                new PermissionSite {Id = 1, PId = 0, PermissionName = "Page", Name = "页面"}
                ,new PermissionSite {Id = 11, PId = 1, PermissionName = "Page.Channel", Name = "首页"}
                ,new PermissionSite {Id = 12, PId = 1, PermissionName = "Page.Users", Name = "用户"}
                ,new PermissionSite {Id = 121, PId = 12, PermissionName = "Page.Users.Manage", Name = "用户管理"}
                ,new PermissionSite {Id = 1211, PId = 121, PermissionName = "Page.Users.Manage.Add", Name = "添加用户"}
                ,new PermissionSite {Id = 1212, PId = 121, PermissionName = "Page.Users.Manage.Delete", Name = "删除用户"}
                ,new PermissionSite {Id = 1213, PId = 121, PermissionName = "Page.Users.Manage.Edit", Name = "编辑用户"}
                ,new PermissionSite {Id = 1214, PId = 121, PermissionName = "Page.Users.Manage.SetRoles", Name = "设置角色"}
                ,new PermissionSite {Id = 1215,PId = 121,PermissionName = "Page.Users.Manage.SetPermissions",Name = "设置权限"}
                ,new PermissionSite {Id = 122, PId = 12, PermissionName = "Page.Roles.Manage", Name = "角色管理"}
                ,new PermissionSite {Id = 1221, PId = 122, PermissionName = "Page.Roles.Manage.Add", Name = "添加角色"}
                ,new PermissionSite {Id = 1222, PId = 122, PermissionName = "Page.Roles.Manage.Delete", Name = "删除角色"}
                ,new PermissionSite {Id = 1223, PId = 122, PermissionName = "Page.Roles.Manage.Edit", Name = "编辑角色"}
                ,new PermissionSite {Id = 1224,PId = 122,PermissionName = "Page.Roles.Manage.SetPermissions",Name = "设置权限"}
                ,new PermissionSite {Id = 14, PId = 1, PermissionName = "Login", Name = "登录"}
                ,new PermissionSite {Id = 141, PId = 14, PermissionName = "Login.Channel", Name = "登录前台"}
                ,new PermissionSite {Id = 142, PId = 14, PermissionName = "Login.Admin", Name = "登录后台"}
            };
            context.Set<PermissionSite>().AddOrUpdate(permissionAll.ToArray());

            #endregion
        }
    }
}