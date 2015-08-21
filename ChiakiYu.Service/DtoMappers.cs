using ChiakiYu.Core.AutoMapper;
using ChiakiYu.Model.Roles;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Roles.Dto;
using ChiakiYu.Service.Users.Dto;

namespace ChiakiYu.Service
{
    public class DtoMappers
    {
        public static void MapperRegister()
        {
            AutoMapperHelper.CreateMap<User, UserDto>();
            AutoMapperHelper.CreateMap<Role, RoleDto>();
        }
    }
}