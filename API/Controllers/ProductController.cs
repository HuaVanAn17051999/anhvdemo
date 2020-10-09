
using System.Threading.Tasks;
using Application.Common;
using Application.Contract.Model.Products;
using Application.Entities;
using Application.Logging;
using Application.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("/api/v1/product")]

    public class ProductController : BaseController
    {
        private readonly IProductAppService _productAppService;
        public ProductController(UserManager<User> userManager,
            IProductAppService productAppService)
            :base(userManager)
        {
            _productAppService = productAppService;
        }
        /////<summary>
        ///// create new product async
        /////</summary>
        /////<param name="createProductRequestModel"> product info to create new </param>
        /////<response code = "200"> Create Product successfuly</response>
        /////<response code = "500"> Internal error server</response>
        //[HttpPost]
        //[Authorize(Roles = "Administrator")]
        //public async Task<ActionResult<ProductReponseModel>> CreateAsync([FromForm] CreateProductRequestModel createProductRequestModel)
        //{
        //    const string actionName = nameof(CreateAsync);

        //    Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, createProductRequestModel);
        //    var response =await _productAppService.CreateAsync(createProductRequestModel);
        //    Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

        //    return Ok(response);
        //}

        ///// <summary>
        ///// update product async
        ///// </summary>
        ///// <param name="id">user id to update</param>
        ///// <param name="updateProductRequestModel">product id to update</param>
        ///// <response code="204">update product successfuly</response> 
        ///// <response code="500">Internal error server</response>
        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateAsync(int id, [FromForm] UpdateProductRequestModel updateProductRequestModel)
        //{
        //    const string actionName = nameof(UpdateAsync);
        //    Logger.LogInfomation(LoggingMessage.ProcessingRequestWithModel, actionName, updateProductRequestModel);
        //    var response = await _productAppService.UpdateAsync(id, updateProductRequestModel);
        //    Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

        //    return Ok(response);
        //}
        /// <summary>
        /// delete product async
        /// </summary>
        /// <param name="id">product id to delete</param>
        /// <response code="204">Delete product successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            const string actionName = nameof(DeleteAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, id);
            await _productAppService.DeleteAsync(id);
            Logger.LogDebug(LoggingMessage.RequestResults, actionName);

            return NoContent();
        }

        /// <summary>
        /// GetByCategoriesAsync product async
        /// </summary>
        /// <param name="id">product id to ListProductByCategoryId</param>
        /// <param name="ownerParameters">product id to update</param>
        /// <response code="204">GetListAsync product successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpGet("ListProductByCategoryId/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> ListProductByCategoryId(int id,[FromQuery] OwnerParameters ownerParameters)
        {
            const string actionName = nameof(ListProductByCategoryId);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, id);

            var response = await _productAppService.ListProductByCategoryId(id, ownerParameters);

            var metadata = new
            {
                response.TotalCount,
                response.PageSize,
                response.CurrentPage,
                response.TotalPages,
                response.HasNext,
                response.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            Logger.LogDebug(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }

        /// <summary>
        /// GetByIdsAsync product async
        /// </summary>
        /// <param name="id">product id to getById</param>
        /// <response code="204">GetByIdAsync product successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetById(int id)
        {
            const string actionName = nameof(GetById);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, id);

            var response = await _productAppService.GetByIdAsync(id);

            return Ok(response);
        }
    }
}
