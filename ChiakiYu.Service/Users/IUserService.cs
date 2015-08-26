using System.Linq;
using ChiakiYu.Core.Data;
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
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        User GetUser(long userId);

        /// <summary>
        ///     获取所有用户分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagingList<UserDto> GetUsers(GetUsersInput input);

        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        User AddUser(User user);

        /// <summary>
        ///     验证用户名密码
        /// </summary>
        /// <param name="userName">用户名/注册邮箱/注册手机</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        UserLoginStatus ValidateUser(string userName, string password);

        /// <summary>
        ///     更新用户
        /// </summary>
        /// <param name="user">用户实体</param>
        User UpdateUser(User user);
    }
}