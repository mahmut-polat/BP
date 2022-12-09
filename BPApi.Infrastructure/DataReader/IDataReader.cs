using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BPApi.Infrastructure.DataReader
{
    public interface IDataReader<TResponse>
    {
        IList<TResponse> Read(string path);
    }
}
