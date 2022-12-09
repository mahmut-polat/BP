using BPApi.Application.Features.Queries.GetAllPumps;
using BPApi.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SiteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetSites")]
        public async Task<GetSitesQueryResponse> GetAll(SiteSearchRequestDto request)
        {
            return await _mediator.Send(new GetSitesQueryRequest(request));
        }
    }
}
