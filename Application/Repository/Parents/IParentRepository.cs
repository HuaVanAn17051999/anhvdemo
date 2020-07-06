using Application.Contract.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Parents
{
    public interface IParentRepository : IRepositoryBase<Entities.Parent>
    {
       // Task<IList<Entities.Parent>> GetAvailablesAsync(int )
    }
}
