using Application.Common;
using Application.Contract.Model.Common;
using Application.Contract.Model.Products;
using Application.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Mapping
{
    public class ProductAutoMapperProfile : Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<CreateProductRequestModel, Product>();
            CreateMap<UpdateProductRequestModel, Product>();
            CreateMap<Product, ProductReponseModel>();

            CreateMap<PagedList<Product>, PagedList<ProductReponseModel>>();


            CreateMap<PageResultData<Product>, PageResultData<ProductReponseModel>>();
          //  CreateMap<PagedList<Product>, PagedList<ProductReponseModel>>();
        }
    }
}
