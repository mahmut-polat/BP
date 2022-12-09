using BPApi.Domain.Common;
using BPApi.Domain.Dtos;
using MediatR;
using System.Collections.Generic;

namespace BPApi.Application.Features.Queries.GetAllPumps
{
    public sealed class GetSitesQueryResponse : BaseResponse, IRequest
    {
        public IList<SiteDto> Sites { get; set; }
    }
}
