using Application.Contract.Model.Common;
using Application.Contract.Model.Parents;
using Application.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Mapping
{
    public class ParentAutoMapperProfile : Profile
    {
        public ParentAutoMapperProfile()
        {
            CreateMap<CreateParentRequestModel, Parent>();
            CreateMap<UpdateParentRequestModel, Parent >();
            CreateMap<PageResultData<Parent>, PageResultData<ParentReponseModel>>();
               

        }
    }
}
