using BPApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPApi.Application.Interfaces.Repositories
{
    public interface IPumpRepository
    {
        Task<IList<Pump>> GetPumpsBySiteCode();  
        Task<Pump> GetPump(string siteCode, string pumpCode);
    }
}
