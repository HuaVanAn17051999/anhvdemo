using Application.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected UserManager<User> userManager;    
        public BaseController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        private User currentUser;
        public User CurrentUser
        {
            get
            {
                if(currentUser == null)
                {
                    var userId = userManager.GetUserId(this.User);
                    if (!string.IsNullOrEmpty(userId))
                    {
                        var user = userManager.FindByIdAsync(userId).Result;
                        if(user != null)
                        {
                            currentUser = user;
                        }
                    }
                }
                return currentUser;
            }
        }
    }
}
