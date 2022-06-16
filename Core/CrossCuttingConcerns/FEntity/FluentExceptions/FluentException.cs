using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentEntity_ConsoleApp.FEntity.FluentExceptions
{
    public class FluentException : Exception
    {
        public FluentException() : base()
        {
        }

        public FluentException(string message) : base(message)
        {
        }

        public FluentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
