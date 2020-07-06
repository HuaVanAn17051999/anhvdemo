
using System.Threading.Tasks;
using Application.Contract.Model.Parents;
using Application.Entities;
using Application.Logging;
using Application.Services.Parent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/api/v1/parents")]
    public class ParentController : BaseController
    {
        private readonly IParentAppService _parentAppService;
        public ParentController(UserManager<User> userManager,
            IParentAppService parentAppService)
            : base(userManager)
        {
            _parentAppService = parentAppService; 
        }
        /// <summary>
        /// create new topic async
        /// </summary>
        /// <param name="createParentRequestModel">topic info to create new</param>
        /// <response code="200">Create topic successfuly</response> 
        /// <response code="500">Internal error server</response>
        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ParentReponseModel>> CreateAsync([FromBody] CreateParentRequestModel createParentRequestModel)
        {
            const string actionName = nameof(CreateAsync);

            Logger.LogDebug(LoggingMessage.ProcessingRequestWithModel, actionName, createParentRequestModel);
            var respone = await _parentAppService.CreateAsync(createParentRequestModel);
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(respone);
        }
    }
}
