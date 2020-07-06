using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Exceptions
{
    public class LoginInvalidException : Exception
    {
        public LoginInvalidException() : base("Your UserName or Password incorrect.")
        {

        }
      
    }
}
