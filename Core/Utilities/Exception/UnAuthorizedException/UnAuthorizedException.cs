﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Exception.UnAuthorizedException
{
    public class UnAuthorizedException : SystemException
    {
        public UnAuthorizedException(string message) : base(message)
        {
        }

        public UnAuthorizedException()
        {
        }

        public UnAuthorizedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
