using Application.Contract.Criteria.Users;
using Application.Contract.Model.Common;
using Application.Contract.Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Users
{
    public interface IUserRepository : IRepositoryBase<Entities.User>
    {
        Task<PageResultData<Entities.User>> SearchAsync(UserCriteria criteria);
        Task<List<UserReponseList>> ListUserAsync();
        Task<UserResponseModel> BydIdAsync(int id);

    }
}
