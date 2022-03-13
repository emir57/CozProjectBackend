using Newtonsoft.Json;
using System;
using System.Text;

namespace Core.Utilities.Middleware
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
