using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class BaseAppService
    {
        protected IMapper _Mapper;
        protected UserManager<Entities.User> _userManager;
        protected IHttpContextAccessor _httpContextAccessor;

        public BaseAppService(IMapper mapper, UserManager<Entities.User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _Mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public BaseAppService(IMapper mapper)
        {

        }
        private Entities.User currenUser;
        public Entities.User CurrentUser
        {
            get
            {
                if(currenUser == null)
                {
                    var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
                    if (!string.IsNullOrEmpty(userId))
                    {
                        var user = _userManager.FindByIdAsync(userId).Result;
                        if (user != null)
                        {
                            currenUser = user;
                        }
                    }
                }
                return currenUser;
            }
        }
    }
}
