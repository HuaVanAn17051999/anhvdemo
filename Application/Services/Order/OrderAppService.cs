using Application.Contract.Exceptions;
using Application.Contract.Model.Order;
using Application.Logging;
using Application.Repository.Order;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Order
{
    public class OrderAppService : BaseAppService, IOrderAppService
    {
        private readonly string seviceName = nameof(OrderAppService);
        private readonly IOrderRepository _orderRepository;
        public OrderAppService(IMapper mapper,
            UserManager<Entities.User> userManager,
            IHttpContextAccessor httpContextAccessor,
            IOrderRepository orderRepository)
            : base(mapper, userManager, httpContextAccessor)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderReponseModel> CreateAsync(CreateOrderRequestModel createOrderRequestModel)
        {
            var actionName = nameof(CreateAsync);

            createOrderRequestModel = createOrderRequestModel ?? throw new ArgumentNullException(nameof(createOrderRequestModel));

            Logger.LogInfomation(LoggingMessage.ProcessingInService, actionName, seviceName, createOrderRequestModel);

            var listOrder = createOrderRequestModel.OrderDetails;

            var listOrderDetails = new List<Entities.OrderDetail>();

            foreach (var item in listOrder)
            {
                listOrderDetails.Add(new Entities.OrderDetail()
                {
                    ProductId  = item.ProductId,
                    Quantity = item.Quantity,
                  
                    Price = item.Price
                });
            }
            var order = new Entities.Order()
            {
                ShipName = createOrderRequestModel.ShipName,
                ShipPhoneNumber = createOrderRequestModel.ShipPhoneNumber,
                ShipAddress = createOrderRequestModel.ShipAddress,
                UserId = createOrderRequestModel.UserId,
                OrderDate = DateTime.Now,
                OrderDetails = listOrderDetails
            };
            
            var response = await _orderRepository.CreateAsync(order, true);

            Logger.LogInfomation(LoggingMessage.ActionSuccessfully, actionName, seviceName, createOrderRequestModel);

            return _Mapper.Map<OrderReponseModel>(order);

        }
        public async Task<OrderReponseModel> UpdateAsync(int id, UpdateOrderRequestModel updateOrderRequestModel)
        {
            var actionName = nameof(UpdateAsync);

            updateOrderRequestModel = updateOrderRequestModel ?? throw new ArgumentNullException(nameof(updateOrderRequestModel));

            if (id != updateOrderRequestModel.Id)
                throw new InconsistentException(nameof(id));

            Logger.LogInfomation(LoggingMessage.ProcessingInService, actionName, seviceName, updateOrderRequestModel);

            var order = _Mapper.Map<Entities.Order>(updateOrderRequestModel);
            var response = await _orderRepository.UpdateAsync(order, true);
            Logger.LogInfomation(LoggingMessage.ActionSuccessfully, actionName, seviceName, updateOrderRequestModel);

            return _Mapper.Map<OrderReponseModel>(response);
        }
        public async Task DeleteAsync(int id)
        {
            var actionName = nameof(DeleteAsync);
            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, id);
            await _orderRepository.DeleteAsync(id);
            Logger.LogDebug(LoggingMessage.ActionSuccessfully, actionName, seviceName, id);

        }
    }
}
