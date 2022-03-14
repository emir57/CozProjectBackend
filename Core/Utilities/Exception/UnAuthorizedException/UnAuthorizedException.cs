using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Exception.UnAuthorizedException
{
    public class UnAuthorizedException : SystemException
    {
        public UnAuthorizedException(string message) : base(message)
        {
        }
    }
}
