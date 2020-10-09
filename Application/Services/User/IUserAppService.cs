using Application.Contract.Common;
using Application.Contract.Criteria.Users;
using Application.Contract.Model.Common;
using Application.Contract.Model.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public interface  IUserAppService : IAppService<Entities.User>
    {
        Task<JwTAuthRepsonseModel> LoginAsync(HttpContext context);
        Task<UserResponseModel> CreateAsync(CreateUserRequestModel createUserRequestModel);
        Task<UserResponseModel> UpdateAsync(int id, UpdateUserRequestModel updateUserRequestModel);
        Task<PageResultData<UserResponseModel>> SearchAsync(UserCriteria criteria);
        Task<List<UserReponseList>> ListUserAsync();
        Task<UserResponseModel> GetById(int id);
        Task DeleteAsync(int id);

    }
 }
