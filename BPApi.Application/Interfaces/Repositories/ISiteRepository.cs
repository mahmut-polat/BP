using BPApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPApi.Application.Interfaces.Repositories
{
    public interface ISiteRepository
    {
        Task<IList<Site>> GetAll();
    }
}
