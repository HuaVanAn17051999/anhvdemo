using Application.Contract.Model.Common;
using Application.Contract.Model.Role;
using Application.Logging;
using Application.Repository.Roles;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Roles
{
    public class RoleService : BaseAppService , IRoleService
    {
        private readonly string seviceName = nameof(RoleService);
        private readonly IRoleRepository _roleRepository;
        private readonly JwTOption _options;

        public RoleService(IMapper mapper,
            UserManager<Entities.User> userManager,
            IHttpContextAccessor httpContextAccessor,
            JwTOption options,
            IRoleRepository roleRepository)
            : base(mapper, userManager, httpContextAccessor)
        { 
            _options = options;
            _roleRepository = roleRepository;

        }

        public async Task<List<RoleResponseModel>> ListRoleAsync()
        {
            var action = nameof(ListRoleAsync);
            Logger.LogInfomation(LoggingMessage.ProcessingInServiceWithoutModel, action, seviceName);
            var response = await _roleRepository.GetListAsync();
            Logger.LogInfomation(LoggingMessage.ProcessingInServiceSuccessfully, action, seviceName);
            return _Mapper.Map<List<RoleResponseModel>>(response);
        }
    }
}
