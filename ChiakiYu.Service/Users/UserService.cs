using System.Collections.Generic;
using System.Linq;
using ChiakiYu.Common.Data;
using ChiakiYu.Core.AutoMapper;
using ChiakiYu.Core.Data;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Users.Dto;

namespace ChiakiYu.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User, long> _userRepository;

        public UserService(IRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        ///     获取 用户信息查询数据集
        /// </summary>
        public IQueryable<User> GetAll()
        {
            return _userRepository.Table;
        }

        /// <summary>
        ///     根据主键获取实体
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public User GetUser(long userId)
        {
            return _userRepository.Get(userId);
        }

        /// <summary>
        ///     获取用户分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingList<UserDto> GetUsers(GetUsersInput input)
        {
            var query = _userRepository.Table;
            if (!string.IsNullOrWhiteSpace(input.NameKeyWords))
                query = query.Where(m => m.UserName.Contains(input.NameKeyWords) || m.NickName.Contains(input.NameKeyWords) || m.TrueName.Contains(input.NameKeyWords));
            if (!string.IsNullOrWhiteSpace(input.EmailAddress))
                query = query.Where(n => n.AccountEmail.Contains(input.EmailAddress));
            if (input.IsActive.HasValue)
                query = query.Where(n => n.IsActived == input.IsActive.Value);
            var source = query.OrderBy(n => n.Id)
                              .Skip((input.PageIndex - 1) * input.PageSize)
                              .Take(input.PageSize)
                              .MapTo<List<UserDto>>();

            var result = new PagingList<UserDto>(source, input.PageIndex, input.PageSize,query.LongCount());
            return result;
        }

        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        public User AddUser(User user)
        {
            return _userRepository.Insert(user);
        }

        /// <summary>
        ///     验证用户名密码
        /// </summary>
        /// <param name="userName">用户名/注册邮箱/注册手机</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public UserLoginStatus ValidateUser(string userName, string password)
        {
            var user =
                _userRepository.Table
                    .FirstOrDefault(
                        n => n.UserName == userName || n.AccountEmail == userName || n.AccountMobile == userName);
            if (user == null)
                return UserLoginStatus.IsNotExist;
            if (!UserPasswordHelper.CheckPassword(password, user.Password, user.PasswordFormat))
                return UserLoginStatus.InvalidCredentials;
            return !user.IsActived ? UserLoginStatus.NotActivated : UserLoginStatus.Success;
        }

        /// <summary>
        ///     更新用户
        /// </summary>
        /// <param name="user">用户实体</param>
        public User UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }
    }
}