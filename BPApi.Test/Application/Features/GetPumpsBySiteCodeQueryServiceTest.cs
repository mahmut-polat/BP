using AutoMapper;
using BPApi.Application;
using BPApi.Application.Features.Queries.GetPumpsBySiteCode;
using BPApi.Application.Features.Queries.GetPumpsBySiteCode.Validators;
using BPApi.Application.Interfaces.Repositories;
using BPApi.Application.Mapping;
using BPApi.Test.Mocks;
using FluentValidation;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BPApi.Test.Application.Features
{
    public class GetPumpsBySiteCodeQueryServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPumpRepository> _mockPumpRepository;
        private readonly AbstractValidator<GetPumpsBySiteCodeQueryRequest> _requestValidator;

        public GetPumpsBySiteCodeQueryServiceTest()
        {
            _mockPumpRepository = MockPumpRepository.GetPumpRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _requestValidator = new GetPumpsBySiteCodeRequestValidator();
        }   

        [Fact]
        public async Task GetPumpsBySiteCode_ShouldNotBeValid_WhenSiteCodeIsNull()
        {
            var handler = new GetPumpsBySiteCodeQueryHandler(_mapper, _mockPumpRepository.Object, _requestValidator);
            var result = await handler.Handle(new GetPumpsBySiteCodeQueryRequest(null), CancellationToken.None);

            Assert.False(result.IsSuccessful);
            Assert.Null(result.Pumps);
            Assert.NotNull(result.Errors);
            Assert.Equal(Constants.NOT_EMPTY_SITE_CODE_ERROR_TEXT, result.Errors[0].Message);
        }

        [Fact]
        public async Task GetPumpsBySiteCode_ShouldNotBeValid_WhenSiteCodeIsEmpty()
        {
            var handler = new GetPumpsBySiteCodeQueryHandler(_mapper, _mockPumpRepository.Object, _requestValidator);
            var result = await handler.Handle(new GetPumpsBySiteCodeQueryRequest(string.Empty), CancellationToken.None);

            Assert.False(result.IsSuccessful);
            Assert.Null(result.Pumps);
            Assert.NotNull(result.Errors);
            Assert.Equal(Constants.NOT_EMPTY_SITE_CODE_ERROR_TEXT, result.Errors[0].Message);
        }

        [Fact]
        public async Task GetPumpsBySiteCode_ShouldPumpsReturned_WhenSiteCodeReceived()
        {
            var handler = new GetPumpsBySiteCodeQueryHandler(_mapper, _mockPumpRepository.Object, _requestValidator);
            var result = await handler.Handle(new GetPumpsBySiteCodeQueryRequest(MockPumpRepository.SITE_CODE), CancellationToken.None);

            Assert.True(result.IsSuccessful);
            Assert.NotNull(result.Pumps);
            Assert.Null(result.Errors);
            Assert.Equal(3, result.Pumps.Count);
        }
    }
}
