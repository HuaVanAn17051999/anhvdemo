using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base($"Cannot found data requested by {message}") 
        {
        }
    }
}
