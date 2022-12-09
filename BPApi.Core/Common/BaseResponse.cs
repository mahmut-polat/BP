using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Domain.Common
{
    public class BaseResponse : IResponse
    {
        public bool IsSuccessful { get; set; } = true;
        public IList<Error> Errors { get; set; } = null;
    }
}
