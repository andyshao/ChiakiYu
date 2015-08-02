using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using ChiakiYu.Common.Data;
using ChiakiYu.Common.Extensions;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Authorization;
using ChiakiYu.Service.Roles;
using ChiakiYu.Service.Roles.Dto;
using ChiakiYu.Service.Users;
using ChiakiYu.Service.Users.Dto;
using ChiakiYu.Web.Areas.Admin.Controllers.Filters;
using ChiakiYu.Web.Areas.Admin.ViewModels;

namespace ChiakiYu.Web.Areas.Admin.Controllers
{
    [ManageAuthorize(RequireSystemAdministrator = true)]
    public partial class AdminUserController : Controller
    {
        #region 构造函数

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IAuthorizationService _authorizationService;

        public AdminUserController(IUserService userService,
            IRoleService roleService,
            IAuthorizationService authorizationService)
        {
            _userService = userService;
            _roleService = roleService;
            _authorizationService = authorizationService;
        }

        #endregion

        #region 用户

        /// <summary>
        ///     用户管理
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        public virtual ActionResult ManageUsers(int pageIndex = 1, int pageSize = 5)
        {
            #region 组装搜索条件

            var input = new GetUsersInput
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                NameKeyWords = Request.QueryString.Get("NameKeyWords", string.Empty),
                EmailAddress = Request.QueryString.Get("EmailAddress", string.Empty),
                IsActive = Request.QueryString.Get<bool?>("IsActive", null)
            };

            #endregion

            #region 组装搜索下拉列表

            var activatedValues = new Dictionary<bool, string> { { true, "已激活" }, { false, "未激活" } };
            ViewData["IsActived"] =
                new SelectList(activatedValues.Select(n => new { text = n.Value, value = n.Key.ToString().ToLower() }),
                    "value", "text", input.IsActive);

            #endregion

            var user = _userService.GetUsers(input);

            return View(user);
        }

        public virtual ActionResult EidtUser(long userId)
        {
            var model = new UserEditModel();
            return View(model);
        }

        [HttpPost]
        public virtual JsonResult EidtUser()
        {
            return Json(new { MessageType = 1, MessageContent = "设置成功" });
        }

        #endregion

        #region 角色

        /// <summary>
        ///     角色管理
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        public virtual ActionResult ManageRoles(int pageIndex = 1, int pageSize = 5)
        {
            var input = new GetRolesInput
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var roles = _roleService.GetRoles(input);

            return View(roles);
        }

        /// <summary>
        ///     设置角色 页面
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual ActionResult SetRoles(long userId)
        {
            var user = _userService.GetUser(userId);

            var roles = _roleService.GetRoles();
            var list = user.Roles.ToList();

            ViewData["UserId"] = userId;
            ViewData["UserRoleList"] = list;
            return View(roles);
        }

        /// <summary>
        ///     设置角色提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual JsonResult SetRoles()
        {
            var userId = Request.Form.Get<long>("userId", 0);
            if (userId <= 0)
            {
                return Json(new { MessageType = 0, MessageContent = "请选择某个用户设置角色！" });
            }
            var roleIdStr = Request.Form.Get("roleId");

            if (string.IsNullOrEmpty(roleIdStr)) return Json(new { MessageType = 0, MessageContent = "请至少分配一项角色！" });
            var roleIds = roleIdStr.Split(',');
            _authorizationService.DeleteUserRole(userId);
            foreach (var userRole in roleIds.Select(item => new UserRole(userId, Convert.ToInt32(item))))
            {
                _authorizationService.AddUserRole(userRole); //todo 处理单个数据异常情况
            }
            return Json(new { MessageType = 1, MessageContent = "设置成功" });
        }

        #endregion

        #region 权限设置

        /// <summary>
        ///     更改权限 页面
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public virtual ActionResult ChangePermissions(int roleId)
        {
            ViewData["RoleId"] = roleId;
            return View();
        }

        /// <summary>
        ///     获取站点权限列表组装json
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public virtual ContentResult GetPermissions(int roleId)
        {
            var role = _roleService.GetRole(roleId);
            var rolePermissions = role.Permissions;
            var permissionAll = _authorizationService.GetPermissionAll();
            foreach (var item in permissionAll)
            {
                item.Checked = rolePermissions.Any(n => n.Name == item.PermissionName);
                item.Open = item.Id < 100;
            }
            var result = JsonHelper.ToJson(permissionAll)
                .Replace("Id", "id")
                .Replace("Pid", "pId")
                .Replace("Name", "name")
                .Replace("Open", "open")
                .Replace("Permissionname", "permissionName")
                .Replace("Checked", "checked");

            #region 原xml处理方式
            //var result = string.Empty;
            //const string xmlFile = "App_Data/permission.config";
            //var doc = new XmlDocument();
            //var filename = AppDomain.CurrentDomain.BaseDirectory + xmlFile;
            //doc.Load(filename);
            //var xn = doc.SelectSingleNode("Permissions");

            //if (xn == null || !xn.HasChildNodes) return Content(result);
            //var sb = new StringBuilder();
            //sb.Append("[");
            //for (var i = 0; i < xn.ChildNodes.Count; i++)
            //{
            //    var xmlNode = xn.ChildNodes.Item(i);
            //    if (xmlNode != null)
            //    {
            //        if (xmlNode.Attributes != null)
            //        {
            //            var id = xmlNode.Attributes["id"].Value;
            //            var pId = xmlNode.Attributes["pId"].Value;
            //            var permissionName = xmlNode.Attributes["permissionName"].Value;
            //            var name = xmlNode.Attributes["name"].Value;
            //            var isChecked = "false";
            //            if (role != null && role.Permissions != null &&
            //                role.Permissions.Any(n => n.Name == permissionName))
            //                isChecked = "true";
            //            var isOpen = "true";
            //            if (id.Length > 2)
            //                isOpen = "false";
            //            sb.Append("{");
            //            sb.AppendFormat(
            //                "id: {0}, pId: {1}, name: \"{2}\", permissionName: \"{3}\",open: {4}, checked:{5}",
            //                id, pId, name, permissionName, isOpen, isChecked);
            //        }
            //    }
            //    sb.Append("},");
            //}
            //result = sb.ToString().TrimEnd(',') + "]"; 
            #endregion

            return Content(result);
            //return Content(result);
        }

        /// <summary>
        ///     更改权限 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual JsonResult ChangePermissions()
        {
            var roleId = Request.Form.Get("roleId", 0);
            if (roleId <= 0)
            {
                return Json(new { MessageType = 0, MessageContent = "请选择某个角色更改权限！" });
            }
            var permissionNameStr = Request.Form.Get("permissionName");


            if (string.IsNullOrEmpty(permissionNameStr)) return Json(new { MessageType = 0, MessageContent = "设置失败" });
            var permissionNames = permissionNameStr.Split(',');
            _authorizationService.DeleteRolePermission(roleId);

            foreach (var rp in from item in permissionNames
                               where !string.IsNullOrEmpty(item)
                               select new RolePermission
                               {
                                   RoleId = roleId,
                                   Name = item
                               })
            {
                _authorizationService.AddRolePermission(rp); //todo 处理单个数据异常情况
            }

            return Json(new { MessageType = 1, MessageContent = "设置成功" });
        }

        #endregion
    }
}