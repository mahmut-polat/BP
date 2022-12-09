using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Domain.Common
{
    public class Error
    {
        public string Type { get; private set; }
        public string Message { get; private set; } 

        public Error(string type, string message)
        {
            Type = type;
            Message = message;
        }   
    }
}
