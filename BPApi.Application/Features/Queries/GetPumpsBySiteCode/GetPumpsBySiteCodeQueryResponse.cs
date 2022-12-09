using BPApi.Domain.Common;
using BPApi.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Application.Features.Queries.GetPumpsBySiteCode
{
    public sealed class GetPumpsBySiteCodeQueryResponse : BaseResponse, IRequest
    {
        public IList<PumpDto> Pumps { get; set; }
    }
}
