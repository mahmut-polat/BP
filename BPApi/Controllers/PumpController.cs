using BPApi.Application.Features.Commands.FillUpFuel;
using BPApi.Application.Features.Queries.GetPumpsBySiteCode;
using BPApi.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PumpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPumps/{siteCode}")]
        public async Task<GetPumpsBySiteCodeQueryResponse> Get(string siteCode)
        {
            return await _mediator.Send(new GetPumpsBySiteCodeQueryRequest(siteCode));
        }

        [HttpPost("FillUp")]
        public async Task<FillUpFuelCommandResponse> FillUpFuel(FillUpRequestDto request)
        {
            return await _mediator.Send(new FillUpFuelCommandRequest(request.SiteCode, request.PumpCode, request.FuelAmount));
        }
    }
}
