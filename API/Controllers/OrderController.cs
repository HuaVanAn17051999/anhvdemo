using Application.Contract.Model.Order;
using Application.Entities;
using Application.Logging;
using Application.Services.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("/api/v1/order")]
    public class OrderController : BaseController
    {
        private readonly IOrderAppService _orderAppService ;
        public OrderController(UserManager<User> userManager,
            IOrderAppService orderAppService)
            : base(userManager)
        {
            _orderAppService = orderAppService;
        }
        ///<summary>
        /// create new Order async
        ///</summary>
        ///<param name="createOrderRequestModel"> Order info to create new </param>
        ///<response code = "200"> Create Order successfuly</response>
        ///<response code = "500"> Internal error server</response>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateAsync([FromBody]CreateOrderRequestModel createOrderRequestModel)
        {
            const string actionName = nameof(CreateAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, createOrderRequestModel);
            var response = await _orderAppService.CreateAsync(createOrderRequestModel);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }
        /// <summary>
        /// update order async
        /// </summary>
        /// <param name="id">order id to update</param>
        /// <param name="updateOrderRequestModel">order id to update</param>
        /// <response code="204">update order successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateAsync(int id, UpdateOrderRequestModel updateOrderRequestModel)
        {
            const string actionName = nameof(updateOrderRequestModel);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, updateOrderRequestModel);
            var response = await _orderAppService.UpdateAsync(id, updateOrderRequestModel);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }

        /// <summary>
        /// delete order async
        /// </summary>
        /// <param name="id">order id to delete</param>
        /// <response code="204">Delete order successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            const string actionName = nameof(DeleteAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, id);
            await _orderAppService.DeleteAsync(id);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return NoContent();
        }
    }
}
