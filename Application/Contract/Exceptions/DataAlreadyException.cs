using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Exceptions
{
    [Serializable]
    public class DataAlreadyException : Exception
    {
        public DataAlreadyException(string message) : base($"Data already exists: {message}")
        {

        }
    }
}
