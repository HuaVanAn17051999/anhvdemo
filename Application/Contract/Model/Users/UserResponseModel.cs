using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Users
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Role { get; set; }
    }
}
