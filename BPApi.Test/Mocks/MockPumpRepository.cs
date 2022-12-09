using BPApi.Application.Interfaces.Repositories;
using BPApi.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BPApi.Test.Mocks
{
    public static class MockPumpRepository
    {
        public static readonly string SITE_CODE = "1";
        public static readonly string UNLOCKED_PUMP_CODE = "2";
        public static readonly string LOCKED_PUMP_CODE = "3";
        public static readonly double REMAINED_LITRES = 30;

        public static Mock<IPumpRepository> GetPumpRepository()
        {
            var mockedPumps = GetPumps();
            var mockRepository = new Mock<IPumpRepository>();

            var sitesPumps = mockedPumps.Where(pump => pump.SiteCode == SITE_CODE).ToList();
            mockRepository.Setup(x => x.GetPumpsBySiteCode()).ReturnsAsync(sitesPumps);

            var lockedPump = mockedPumps.First(pump => pump.SiteCode == SITE_CODE && pump.PumpCode == LOCKED_PUMP_CODE);
            mockRepository.Setup(x => x.GetPump(SITE_CODE, LOCKED_PUMP_CODE)).ReturnsAsync(lockedPump);

            var unlockedPump = mockedPumps.First(pump => pump.SiteCode == SITE_CODE && pump.PumpCode == UNLOCKED_PUMP_CODE);
            mockRepository.Setup(x => x.GetPump(SITE_CODE, UNLOCKED_PUMP_CODE)).ReturnsAsync(unlockedPump);

            return mockRepository;
        }

        private static IList<Pump> GetPumps()
        {
            return new List<Pump>()
            {
                new Pump()
                {
                    Id = 1,
                    SiteCode = "1",
                    PumpCode = "1",
                    Price = 1,
                    RemainedLitres = REMAINED_LITRES,
                    Type = Domain.Enums.PumpType.Diesel,
                    IsLocked = false,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Pump()
                {
                    Id = 2,
                    SiteCode = "1",
                    PumpCode = "2",
                    Price = 1,
                    RemainedLitres = REMAINED_LITRES,
                    Type = Domain.Enums.PumpType.Petrol,
                    IsLocked = false,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Pump()
                {
                    Id = 3,
                    SiteCode = "1",
                    PumpCode = "3",
                    Price = 1,
                    RemainedLitres = REMAINED_LITRES,
                    Type = Domain.Enums.PumpType.Petrol,
                    IsLocked = true,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Pump()
                {
                    Id = 4,
                    SiteCode = "2",
                    PumpCode = "4",
                    Price = 1,
                    RemainedLitres = REMAINED_LITRES,
                    Type = Domain.Enums.PumpType.Petrol,
                    IsLocked = false,
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            };
        }
    }
}
