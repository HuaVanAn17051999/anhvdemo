using Application.Contract.Model.Categories;
using Application.Contract.Model.Common;
using Application.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Mapping
{
    public class CategoriesAutoMapperProfile  : Profile
    {
        public CategoriesAutoMapperProfile()
        {
            CreateMap<CreateCategoriesRequestModel, Categories>();
            CreateMap<UpdateCategoriesRequestModel, Categories>();
            CreateMap<PageResultData<Categories>, PageResultData<CategoriesReponseModel>>();  
        }
    }
}
