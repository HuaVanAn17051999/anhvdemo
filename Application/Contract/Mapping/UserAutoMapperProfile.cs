using System.Linq;
using Application.Contract.Model.Common;
using Application.Contract.Model.Users;
using Application.Entities;
using AutoMapper;

namespace Application.Contract.Mapping
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<UpdateUserRequestModel, User>();
            CreateMap<User, UserResponseModel>()
                .ForMember(x => x.Role, opt =>
                {
                    opt.PreCondition(src => (src.UserRoles != null && src.UserRoles.Any()));
                    opt.MapFrom(d => d.UserRoles.First().Role.Name);
                });
            CreateMap<CreateUserRequestModel, User>();
            CreateMap<UpdateUserRequestModel, User>();
            CreateMap<PageResultData<User>, PageResultData<UserResponseModel>>();
        }
    }
}
