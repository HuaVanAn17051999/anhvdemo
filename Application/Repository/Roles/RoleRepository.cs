using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository.Roles
{
    public class RoleRepository : RespositoryBase<Entities.Role, ShopDbContext>, IRoleRepository
    {
        public RoleRepository(ShopDbContext context) : base(context)
        {

        }

    }
}
