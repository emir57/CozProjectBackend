using System;
using System.Collections.Generic;
using System.Text;

namespace FluentEntity_ConsoleApp.FEntity.FluentExceptions
{
    public class PropertyNotFoundFluentEntityException : FluentException
    {
        public PropertyNotFoundFluentEntityException() : base("Property Not Found")
        {
        }

        public PropertyNotFoundFluentEntityException(string message) : base(message)
        {
        }

        public PropertyNotFoundFluentEntityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
