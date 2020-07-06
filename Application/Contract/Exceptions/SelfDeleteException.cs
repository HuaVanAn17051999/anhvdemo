using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Contract.Exceptions
{
    [Serializable]
    public class SelfDeleteException : Exception
    {
        public SelfDeleteException() : base("Cannot delete user is logged in.")
        {
        }

        protected SelfDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
