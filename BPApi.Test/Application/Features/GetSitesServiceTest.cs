using AutoMapper;
using BPApi.Application.Features.Queries.GetAllPumps;
using BPApi.Application.Features.Queries.GetSites;
using BPApi.Application.Features.Queries.GetSites.Validators;
using BPApi.Application.Helpers.DistanceCalculator;
using BPApi.Application.Helpers.DistanceCalculator.MileDistanceCalculator;
using BPApi.Application.Interfaces.Repositories;
using BPApi.Application.Mapping;
using BPApi.Domain.Dtos;
using BPApi.Test.Mocks;
using FluentValidation;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BPApi.Test.Application.Features
{
    public class GetSitesServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ISiteRepository> _mockSiteRepository;
        private readonly Mock<IPumpRepository> _mockPumpRepository;
        private readonly IDistanceCalculator _distanceCalculator;
        private readonly AbstractValidator<GetSitesQueryRequest> _requestValidator;

        public GetSitesServiceTest()
        {
            _mockSiteRepository = MockSiteRepository.GetSiteRepository();
            _mockPumpRepository = MockPumpRepository.GetPumpRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _distanceCalculator = new MileDistanceCalculator();
            _requestValidator = new GetSitesRequestValidator();
        }

        [Fact]
        public async Task GetSites_ShouldSitesReturned()
        {
            var request = new SiteSearchRequestDto();

            request.ItemCount = 10;
            request.Latitude = 0;
            request.Longitude = 0;
            request.SiteName = null;

            var handler = new GetSitesQueryHandler(_mapper, _mockSiteRepository.Object, _mockPumpRepository.Object, _distanceCalculator, _requestValidator);
            var result = await handler.Handle(new GetSitesQueryRequest(request), CancellationToken.None);

            Assert.True(result.IsSuccessful);
            Assert.NotNull(result.Sites);
            Assert.Null(result.Errors);
        }
    }
}
