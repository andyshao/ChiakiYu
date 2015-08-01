using AutoMapper;
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
            //Identity
            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<RoleDto, Role>();
        }
    }
}
