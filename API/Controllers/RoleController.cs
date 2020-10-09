
using Application.Entities;
using Application.Logging;
using Application.Services.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("/api/v1/Role")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(UserManager<User> userManager, IRoleService roleService) : base (userManager)
        {
            _roleService = roleService;
        }
        /// <summary>
        /// ListRole user async
        /// </summary>
        /// <response code="204">ListRole user successfuly</response> 
        /// <response code="500">Internal error server</response>
        [HttpGet]
        [Authorize(Roles = "Administrator")]
      
        public async Task<ActionResult> GetListRoleAsync()
        {
            const string actionName = nameof(GetListRoleAsync);
            Logger.LogDebug(LoggingMessage.ProcessingRequest, actionName);
            var response = await _roleService.ListRoleAsync();
            Logger.LogInfomation(LoggingMessage.RequestResults, actionName);

            return Ok(response);
        }
    }
}
