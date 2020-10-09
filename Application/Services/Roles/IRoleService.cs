using Application.Contract.Model.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Roles
{
    public interface IRoleService : IAppService<Entities.Role>
    {
        Task<List<RoleResponseModel>> ListRoleAsync();
    }
}
