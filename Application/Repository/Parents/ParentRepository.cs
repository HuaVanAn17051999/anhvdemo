using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository.Parents
{
    public class ParentRepository : RespositoryBase<Entities.Parent, ShopDbContext>, IParentRepository
    {
        public ParentRepository(ShopDbContext context) : base(context)
        {

        }
        
    }
}
