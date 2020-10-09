using Application.Contract.Model.Order;
using Application.Repository.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Order
{
    public interface IOrderAppService : IAppService<Entities.Order>
    {
        Task<OrderReponseModel> CreateAsync(CreateOrderRequestModel createOrderRequestModel);
        Task<OrderReponseModel> UpdateAsync(int id, UpdateOrderRequestModel updateOrderRequestModel);
        Task DeleteAsync(int id);
    }
}
