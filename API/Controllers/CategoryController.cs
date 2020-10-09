
using System.Threading.Tasks;
using Application.Contract.Criteria.Categoies;
using Application.Contract.Model.Categories;
using Application.Contract.Model.Common;
using Application.Entities;
using Application.Logging;
using Application.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/api/v1/categories")]

    public class CategoryController : BaseController
    {
        private readonly ICategoriesAppService _categoriesAppService;
        public CategoryController(UserManager<User> userManager,
            ICategoriesAppService categoriesAppService)
            : base(userManager)
        {
            _categoriesAppService = categoriesAppService;
        }
        /// <summary>
        /// create new category async
        /// </summary>
        /// <param name="createCategoriesRequestModel">category info to create new</param>
        /// <response code="200">reate user successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<CategoriesReponseModel>> CreateAsync([FromBody] CreateCategoriesRequestModel createCategoriesRequestModel)
        {
            const string actionName = nameof(CreateAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, createCategoriesRequestModel);
            var respone = await _categoriesAppService.CreateAsync(createCategoriesRequestModel);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(respone);
        }
        /// <summary>
        /// update category async
        /// </summary>
        /// <param name="categoryId">categoryId to update new</param>
        /// <param name="updateCategoriesRequestModel">category info to update new</param>
        /// <response code="200">reate user successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpPut("{categoryId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateAsync(int categoryId, UpdateCategoriesRequestModel updateCategoriesRequestModel)
        {
            const string actionName = nameof(UpdateAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithParameter, actionName, updateCategoriesRequestModel);

            var response = await _categoriesAppService.UpdateAsync(categoryId, updateCategoriesRequestModel);
            Logger.LogDebug(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }
        /// <summary>
        /// delete category async
        /// </summary>
        /// <param name="id">category id to delete</param>
        /// <response code="204">Delete category successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            const string actionName = nameof(DeleteAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, id);

            await _categoriesAppService.DeleteAsync(id);
            Logger.LogDebug(LoggingMessage.RequestResults, actionName);

            return NoContent();
        }
        /// <summary>
        ///     search categoies async
        /// </summary>
        /// <param name="criteria"> criteria to search </param> 
        /// <response code="200">Retrieve list topic successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpPost("search")]
        public async Task<ActionResult<PageResultData<CategoriesReponseModel>>>SearchAsync([FromBody] CategoriesCriteria criteria)
        {
            const string actionName = nameof(SearchAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, criteria);
            var response = await _categoriesAppService.SearchAsync(criteria);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);

        }
        /// <summary>
        ///     GetListAsync categoies async
        /// </summary>
        /// <response code="200">listParent successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpGet]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetListAsync()
        {
            const string actionName = nameof(GetListAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequest, actionName);
            var response = await _categoriesAppService.GetListAsync();
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);


        }
    }
}
