using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Order
{
    public class UpdateOrderRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhoneNumber { get; set; }
    }
}
