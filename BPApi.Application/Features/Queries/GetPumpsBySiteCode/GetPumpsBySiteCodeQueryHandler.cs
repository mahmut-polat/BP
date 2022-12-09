using AutoMapper;
using BPApi.Application.Helpers.Utilities;
using BPApi.Application.Interfaces.Features;
using BPApi.Application.Interfaces.Repositories;
using BPApi.Domain.Dtos;
using BPApi.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BPApi.Application.Features.Queries.GetPumpsBySiteCode
{
    public sealed class GetPumpsBySiteCodeQueryHandler : BaseHandler<GetPumpsBySiteCodeQueryRequest, GetPumpsBySiteCodeQueryResponse>
    {
        private readonly IPumpRepository _repository;
        private readonly IMapper _mapper;

        public GetPumpsBySiteCodeQueryHandler(
            IMapper mapper, 
            IPumpRepository repository,
            AbstractValidator<GetPumpsBySiteCodeQueryRequest> requestValidator
        ) : base(mapper, requestValidator: requestValidator)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public override async Task<GetPumpsBySiteCodeQueryResponse> HandleAsync(GetPumpsBySiteCodeQueryRequest request, CancellationToken cancellationToken)
        {
            var pumps = await _repository.GetPumpsBySiteCode();

            return MapResult(pumps);
        }

        private GetPumpsBySiteCodeQueryResponse MapResult(IList<Pump> pumps)
        {
            var response = new GetPumpsBySiteCodeQueryResponse
            {
                Pumps = new List<PumpDto>(pumps.Count)
            };

            foreach (var pump in pumps)
            {
                var pumpDto = _mapper.Map<PumpDto>(pump);

                pumpDto.Type = PumpUtilities.GetPumpType(pump.Type);

                response.Pumps.Add(pumpDto);
            }

            return response;
        }
    }
}
