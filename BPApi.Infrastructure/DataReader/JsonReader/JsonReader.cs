using BPApi.Infrastructure.DataReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BPApi.Infrastructure.JsonReader
{
    public class JsonReader<TResponse> : IDataReader<TResponse>
    {
        public IList<TResponse> Read(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                
                return JsonConvert.DeserializeObject<List<TResponse>>(json);
            }
        }
    }
}
