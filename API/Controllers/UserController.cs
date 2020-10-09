using System.Threading.Tasks;
using Application.Contract.Criteria.Users;
using Application.Contract.Exceptions;
using Application.Contract.Model.Common;
using Application.Contract.Model.Users;
using Application.Entities;
using Application.Logging;
using Application.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/v1/users")]
    public class UserController : BaseController
    {
        private readonly IUserAppService _userAppService;
        public UserController(UserManager<User> userManager, IUserAppService userAppService
            ) : base(userManager)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        ///     search users async
        /// </summary>
        /// <param name="criteria"> criteria to search </param> 
        /// <response code="200">Retrieve list topic successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpPost("search")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<PageResultData<UserResponseModel>>> SearchAsync([FromBody] UserCriteria criteria)
        {
            const string actionName = nameof(SearchAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, criteria);
            var response = await _userAppService.SearchAsync(criteria);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }

        /// <summary>
        /// create new user async
        /// </summary>
        /// <param name="createUserRequestModel">user info to create new</param>
        /// <response code="200">Create user successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<UserResponseModel>> CreateAsync([FromBody] CreateUserRequestModel createUserRequestModel)
        {
            const string actionName = nameof(CreateAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, createUserRequestModel);
            var response = await _userAppService.CreateAsync(createUserRequestModel);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }

        /// <summary>
        /// update user async
        /// </summary>
        /// <param name="id">user id to update</param>
        /// <param name="updateUserRequestModel">topic info to update</param>
        /// <response code="200">Create topic successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [AllowAnonymous]
        public async Task<ActionResult<UserResponseModel>> UpdateAsync(int id, [FromBody] UpdateUserRequestModel updateUserRequestModel)
        {
            const string actionName = nameof(UpdateAsync);

            if (id != updateUserRequestModel.Id)
            {
                throw new InconsistentException(nameof(updateUserRequestModel));
            }

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, updateUserRequestModel);
            var response = await _userAppService.UpdateAsync(id, updateUserRequestModel);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);

        }
        /// <summary>
        /// delete user async
        /// </summary>
        /// <param name="id">user id to delete</param>
        /// <response code="204">Delete user successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
     
        public async Task<IActionResult> DeleteAsync(int id)
        {
            const string actionName = nameof(DeleteAsync);
            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, id);
            await _userAppService.DeleteAsync(id);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return NoContent();
        }
        /// <summary>
        /// getById user async
        /// </summary>
        /// <param name="id">user id to getById</param>
        /// <response code="204">GetById user successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            const string actionName = nameof(GetByIdAsync);
            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, id);
            var response = await _userAppService.GetById(id);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }
        /// <summary>
        /// getAll user async
        /// </summary>
        /// <response code="204">GetAll UserAsync successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpGet("ListUserAsync")]
        [Authorize(Roles = "Administrator")]
        [AllowAnonymous]


        public async Task<IActionResult> ListUserAsync()
        {       
            const string actionName = nameof(ListUserAsync);
            Logger.LogDebug(LoggingMessage.ProcessingRequest, actionName);
            var response = await _userAppService.ListUserAsync();
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }

    }
}
