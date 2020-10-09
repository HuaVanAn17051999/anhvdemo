
using Application.Contract.Model.Role;
using Application.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Mapping
{
    public class RoleAutoMapperProfile : Profile
    {
        public RoleAutoMapperProfile()
        { 
            CreateMap<Role, RoleResponseModel>();
        }
    }
}
