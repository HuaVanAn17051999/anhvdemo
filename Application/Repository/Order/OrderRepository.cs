using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository.Order
{
    public class OrderRepository : RespositoryBase<Entities.Order, ShopDbContext>, IOrderRepository
    {
        public OrderRepository(ShopDbContext context) : base(context)
        {

        }
    }
}
