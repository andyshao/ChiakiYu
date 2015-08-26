using ChiakiYu.Core.AutoMapper;
using ChiakiYu.Model.Blogs;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Roles.Dto;
using ChiakiYu.Service.Users.Dto;
using ChiakiYu.Web.Areas.Blog.ViewModels;

namespace ChiakiYu.Web
{
    /// <summary>
    /// AutoMapper配置初始化
    /// </summary>
    public class AutoMapperInitialize
    {
        /// <summary>
        /// AutoMapper全局配置映射配置
        /// </summary>
        public static void Initialize()
        {
            #region User

            AutoMapperHelper.CreateMap<User, UserDto>(); 
            
            #endregion

            #region Role

            AutoMapperHelper.CreateMap<Role, RoleDto>(); 
            
            #endregion

            #region Blog

            AutoMapperHelper.CreateMap<Blog, BlogEditModel>();
            AutoMapperHelper.CreateMap<BlogEditModel, Blog>();//todo

            #endregion
        }
    }
}