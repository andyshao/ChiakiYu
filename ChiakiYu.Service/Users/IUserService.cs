using System.Linq;
using ChiakiYu.Common.Dto;
using ChiakiYu.Core.Dependency;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Users.Dto;

namespace ChiakiYu.Service.Users
{
    public interface IUserService : IDependency
    {
        /// <summary>
        ///     获取 用户信息查询数据集
        /// </summary>
        IQueryable<User> GetAll();

        /// <summary>
        ///     根据主键获取实体
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUser(long userId);

        /// <summary>
        ///     获取所有用户分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagingOutput<UserDto> GetUsers(GetUsersInput input);

        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User AddUser(User user);

        /// <summary>
        ///     验证用户名密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserLoginStatus ValidateUser(string userName, string password);

        /// <summary>
        ///     更新用户
        /// </summary>
        /// <param name="user"></param>
        User UpdateUser(User user);
    }
}