using Application.Contract.Model.OrderDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Contract.Model.Order
{
    public class CreateOrderRequestModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ShipName { get; set; }
        [Required]
        public string ShipAddress { get; set; }
        [Required]
        public string ShipPhoneNumber { get; set; }
        [Required]
        public List<OrderDetailsRequestModel> OrderDetails { get; set; }

    }
}
