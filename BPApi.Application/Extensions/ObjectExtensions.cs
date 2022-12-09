using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPApi.Application.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj)
        {
            return obj == null || obj.Count() == 0;
        }

        public static bool IsNullOrEmpty(this object obj)
        {
            if(obj is string)
            {
                return obj == null || obj.Equals(string.Empty);
            }

            return obj == null;
        }
    }
}
