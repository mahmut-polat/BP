using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Application.Features.Queries.GetPumpsBySiteCode
{
    public sealed class GetPumpsBySiteCodeQueryRequest : IRequest<GetPumpsBySiteCodeQueryResponse>
    {
        public string SiteCode { get; }

        public GetPumpsBySiteCodeQueryRequest(string siteCode)
        {
            SiteCode = siteCode;
        }   
    }
}
