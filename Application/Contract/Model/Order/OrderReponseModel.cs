
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Order
{
    public class OrderReponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
