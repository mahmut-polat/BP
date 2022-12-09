using AutoMapper;
using BPApi.Application;
using BPApi.Application.Features.Commands.FillUpFuel;
using BPApi.Application.Features.Commands.FillUpFuel.Validators;
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
    public class FillUpFuelServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPumpRepository> _mockPumpRepository;
        private readonly AbstractValidator<FillUpFuelCommandRequest> _requestValidator;

        public FillUpFuelServiceTest()
        {
            _mockPumpRepository = MockPumpRepository.GetPumpRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _requestValidator = new FillUpFuelRequestValidator();
        }

        [Theory()]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task FillUpFuel_ShouldNotBeValid_WhenSiteCodeIsNullOrEmpty(string siteCode)
        {
            var handler = new FillUpFuelCommandHandler(_mapper, _mockPumpRepository.Object, _requestValidator);
            var result = await handler.Handle(new FillUpFuelCommandRequest(siteCode, MockPumpRepository.UNLOCKED_PUMP_CODE, 10), CancellationToken.None);

            Assert.False(result.IsSuccessful);
            Assert.NotNull(result.Errors);
            Assert.Equal(Constants.NOT_EMPTY_SITE_CODE_ERROR_TEXT, result.Errors[0].Message);
        }

        [Theory()]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task FillUpFuel_ShouldNotBeValid_WhenPumpCodeIsNullOrEmpty(string pumpCode)
        {
            var handler = new FillUpFuelCommandHandler(_mapper, _mockPumpRepository.Object, _requestValidator);
            var result = await handler.Handle(new FillUpFuelCommandRequest(MockPumpRepository.SITE_CODE, pumpCode, 10), CancellationToken.None);

            Assert.False(result.IsSuccessful);
            Assert.NotNull(result.Errors);
            Assert.Equal(Constants.NOT_EMPTY_PUMP_CODE_ERROR_TEXT, result.Errors[0].Message);
        }

        [Fact]
        public async Task FillUpFuel_ShouldNotBeValid_WhenAllRequestIsNull()
        {
            var handler = new FillUpFuelCommandHandler(_mapper, _mockPumpRepository.Object, _requestValidator);
            var result = await handler.Handle(new FillUpFuelCommandRequest(null, null, 10), CancellationToken.None);

            Assert.False(result.IsSuccessful);
            Assert.NotNull(result.Errors);
            Assert.Equal(2, result.Errors.Count);
            Assert.Equal(Constants.NOT_EMPTY_SITE_CODE_ERROR_TEXT, result.Errors[0].Message);
            Assert.Equal(Constants.NOT_EMPTY_PUMP_CODE_ERROR_TEXT, result.Errors[1].Message);
        }

        [Fact]
        public async Task GetPumpsBySiteCode_ShouldFillUpReturned_WhenAllRequestVariablesReceivedWithUnlockedPump()
        {
            var fuelAmount = 10;
            var handler = new FillUpFuelCommandHandler(_mapper, _mockPumpRepository.Object, _requestValidator);
            var result = await handler.Handle(new FillUpFuelCommandRequest(MockPumpRepository.SITE_CODE, MockPumpRepository.UNLOCKED_PUMP_CODE, fuelAmount), CancellationToken.None);

            Assert.True(result.IsSuccessful);
            Assert.Null(result.Errors);
            Assert.Equal(MockPumpRepository.REMAINED_LITRES - fuelAmount, result.RemainedLitres);
            Assert.Equal(fuelAmount, result.FuelAmount);
            Assert.Equal(MockPumpRepository.SITE_CODE, result.SiteCode);
            Assert.Equal(MockPumpRepository.UNLOCKED_PUMP_CODE, result.PumpCode);
        }

        [Fact]
        public async Task GetPumpsBySiteCode_ShouldFillUpReturned_WhenAllRequestVariablesReceivedWithLockedPump()
        {
            var fuelAmount = 10;
            var handler = new FillUpFuelCommandHandler(_mapper, _mockPumpRepository.Object, _requestValidator);
            var result = await handler.Handle(new FillUpFuelCommandRequest(MockPumpRepository.SITE_CODE, MockPumpRepository.LOCKED_PUMP_CODE, fuelAmount), CancellationToken.None);

            Assert.False(result.IsSuccessful);
            Assert.NotNull(result.Errors);
            Assert.Equal(Constants.WARNING_TITLE, result.Errors[0].Type);
            Assert.Equal(Constants.LOCKED_PUMP_WARNING_MESSAGE, result.Errors[0].Message);
        }
    }
}
