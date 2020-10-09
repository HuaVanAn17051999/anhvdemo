using Application.Contract.Model.Order;
using Application.Entities;
using AutoMapper;

namespace Application.Contract.Mapping
{
    public class OrderAutoMapperProfile : Profile
    {
        public OrderAutoMapperProfile()
        {
            CreateMap<CreateOrderRequestModel, Order>();
            CreateMap<UpdateOrderRequestModel, Order>();
            CreateMap<Order, OrderReponseModel>();
        }
    }
}
