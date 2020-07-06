using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Contract.Exceptions
{
    [Serializable]
    public class InconsistentException : Exception
    {
        public InconsistentException(string message)
             : base($"Data is not consistent: {message}")
        {
        }

        protected InconsistentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
