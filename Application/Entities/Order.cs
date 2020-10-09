using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { set; get; }
        public int UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }
        public List<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
    }
}
