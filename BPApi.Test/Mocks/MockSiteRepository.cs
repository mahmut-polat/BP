using BPApi.Application.Interfaces.Repositories;
using BPApi.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;

namespace BPApi.Test.Mocks
{
    public static class MockSiteRepository
    {
        public static Mock<ISiteRepository> GetSiteRepository()
        {
            var mockedSites = GetSites();
            var mockRepository = new Mock<ISiteRepository>();

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(mockedSites);

            return mockRepository;
        }

        private static IList<Site> GetSites()
        {
            return new List<Site>()
            {
                new Site()
                {
                    Id = 12312,
                    SiteName = "First Site",
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Site()
                {
                    Id = 123123,
                    SiteName = "First Site",
                    CreatedBy = "First Employee",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            };
        }
    }
}
