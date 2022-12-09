using BPApi.Application.Interfaces.Repositories;
using BPApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPApi.Persistance.Repositories.Implementations
{
    public class PumpRepository : IPumpRepository
    {
        private readonly IList<Pump> _firstPumps;
        private readonly IList<Pump> _secondPumps;

        public PumpRepository()
        {
            _firstPumps = new List<Pump>()
            {
                new Pump()
                {
                    Id = 156456,
                    SiteCode = "84269388",
                    PumpCode = "1",
                    Price = 188.12M,
                    RemainedLitres = 30,
                    Type = Domain.Enums.PumpType.Diesel,
                    IsLocked = false,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Pump()
                {
                    Id = 357897,
                    SiteCode = "84269388",
                    PumpCode = "3",
                    Price = 165.35M,
                    RemainedLitres = 55,
                    Type = Domain.Enums.PumpType.Petrol,
                    IsLocked = true,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Pump()
                {
                    Id = 45646,
                    SiteCode = "84269388",
                    PumpCode = "4",
                    Price = 165.35M,
                    RemainedLitres = 5,
                    Type = Domain.Enums.PumpType.Petrol,
                    IsLocked = false,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            };

            _secondPumps = new List<Pump>()
            {
                new Pump()
                {
                    Id = 156456,
                    SiteCode = "84269388",
                    PumpCode = "1",
                    Price = 188.12M,
                    RemainedLitres = 30,
                    Type = Domain.Enums.PumpType.Diesel,
                    IsLocked = false,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Pump()
                {
                    Id = 357897,
                    SiteCode = "84269388",
                    PumpCode = "3",
                    Price = 165.35M,
                    RemainedLitres = 55,
                    Type = Domain.Enums.PumpType.Petrol,
                    IsLocked = true,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            };
        }

        public async Task<IList<Pump>> GetPumpsBySiteCode()
        {
            // var sitesPumps = _pumps.Where(pump => pump.SiteCode == siteCode).ToList();
            // It usualy needs to check the SiteCode but in the demo i have removed this functionalty.

            Random random = new Random();
            int number = random.Next(4);
            IList<Pump> pumps;

            if (number == 0)
            {
                pumps = _firstPumps;
            } 
            else
            {
                pumps = _secondPumps;
            }

            return pumps.Where(p => p.IsLocked == false).ToList();
        }

        public async Task<Pump> GetPump(string siteCode, string pumpCode)
        {
            return _firstPumps.FirstOrDefault();
        }
    }
}
