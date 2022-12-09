using BPApi.Domain.Dtos;
using MediatR;

namespace BPApi.Application.Features.Queries.GetAllPumps
{
    public sealed class GetSitesQueryRequest : IRequest<GetSitesQueryResponse> 
    {
        public int ItemCount { get; }
        public double Latidute { get; }
        public double Longitude { get; }
        public string SiteName { get; }

        public GetSitesQueryRequest(SiteSearchRequestDto request)
        {
            ItemCount = request.ItemCount;
            Latidute = request.Latitude;
            Longitude = request.Longitude;
            SiteName = request.SiteName;    
        }
    }
}
