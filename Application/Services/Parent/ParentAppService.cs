using Application.Contract.Model.Parents;
using Application.Logging;
using Application.Repository.Parents;
using Application.Services.Parent;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Parent
{
    public class ParentAppService : BaseAppService, IParentAppService
    {
        private readonly string seviceName = nameof(ParentAppService);
        private readonly IParentRepository _parentAppService;
        public ParentAppService(IMapper mapper,
            UserManager<Entities.User> userManager,
            IHttpContextAccessor httpContextAccessor,
            IParentRepository parentRepository)
            :base(mapper, userManager, httpContextAccessor)
        {
            _parentAppService = parentRepository;
        }
        public async Task<ParentReponseModel> CreateAsync(CreateParentRequestModel createParentRequestModel)
        {
            const string actionName = nameof(CreateAsync);

            createParentRequestModel = createParentRequestModel ?? throw new ArgumentNullException(nameof(createParentRequestModel));

            Logger.LogInfomation(LoggingMessage.ProcessingInService, actionName, seviceName, createParentRequestModel);
            var parent = _Mapper.Map<Entities.Parent>(createParentRequestModel);
            var response = await _parentAppService.CreateAsync(parent, true);
            Logger.LogInfomation(LoggingMessage.ActionSuccessfully, actionName, seviceName, response);

            return _Mapper.Map<ParentReponseModel>(response);
        }

        public Task DeleteAsyc(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ParentReponseModel> UpdateAsync(UpdateParentRequestModel updateParentRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}
