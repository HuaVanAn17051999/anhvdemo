using Application.Contract.Model.Parents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Parent
{
    public interface IParentAppService : IAppService<Entities.Parent>
    {
        Task<ParentReponseModel> CreateAsync(CreateParentRequestModel createParentRequestModel);
        Task<ParentReponseModel> UpdateAsync(UpdateParentRequestModel updateParentRequestModel);
        Task DeleteAsyc(int id);

    }
}
