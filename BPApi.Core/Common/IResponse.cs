using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Domain.Common
{
    public interface IResponse
    {
        public bool IsSuccessful { get; set; }
    }
}
