using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Exception.UnAuthorizeException
{
    public class UnAuthorizeException:SystemException
    {
        public UnAuthorizeException(string message) : base(message)
        {
        }
    }
}
