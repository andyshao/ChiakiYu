using System.Collections.Generic;
using System.Linq;
using ChiakiYu.Common.Data;
using ChiakiYu.Common.Dto;
using ChiakiYu.Common.Extensions;
using ChiakiYu.Core;
using ChiakiYu.Core.AutoMapper;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Core.Domain.UnitOfWork;
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

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(long userId)
        {
            return _userRepository.Get(userId);
        }

        /// <summary>
        ///     获取用户分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingOutput<UserDto> GetUsers(GetUsersInput input)
        {
            var query = _userRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.NameKeyWords),
                    m =>
                        m.UserName.Contains(input.NameKeyWords) || m.NickName.Contains(input.NameKeyWords) ||
                        m.TrueName.Contains(input.NameKeyWords))
                .WhereIf(!string.IsNullOrWhiteSpace(input.EmailAddress),
                    n => n.AccountEmail.Contains(input.EmailAddress))
                .WhereIf(input.IsActive.HasValue, n => n.IsActived == input.IsActive.Value);
            var enumerable = query as User[] ?? query.ToArray();
            return new PagingOutput<UserDto>
            {
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalCount = enumerable.Count(),
                Items =
                    enumerable.Skip((input.PageIndex - 1) * input.PageSize)
                        .Take(input.PageSize)
                        .OrderBy(n => n.Id)
                        .MapTo<List<UserDto>>()
            };
        }

        public User AddUser(User user)
        {
            return _userRepository.Insert(user);
        }

        public UserLoginStatus ValidateUser(string userName, string password)
        {
            var user =
                _userRepository.GetAll()
                    .FirstOrDefault(
                        n => n.UserName == userName || n.AccountEmail == userName || n.AccountMobile == userName);
            if (user == null)
                return UserLoginStatus.IsNotExist;
            if (!UserPasswordHelper.CheckPassword(password, user.Password, user.PasswordFormat))
                return UserLoginStatus.InvalidCredentials;
            return !user.IsActived ? UserLoginStatus.NotActivated : UserLoginStatus.Success;
        }

        public User UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }
    }
}