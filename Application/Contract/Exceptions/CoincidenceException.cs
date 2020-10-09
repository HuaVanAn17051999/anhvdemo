using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Exceptions
{
    [Serializable]
    public class CoincidenceException : Exception
    {
        public CoincidenceException(string message)
            : base($"Data is not coinciden: {message}")
        {

        }
    }
}
