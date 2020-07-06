using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Message { set; get; }
        public Status Status { set; get; }
    }
}
