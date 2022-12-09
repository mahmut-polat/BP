using AutoMapper;
using BPApi.Application.Features.Queries.GetAllPumps;
using BPApi.Application.Helpers.DistanceCalculator;
using BPApi.Application.Helpers.Utilities;
using BPApi.Application.Interfaces.Features;
using BPApi.Application.Interfaces.Repositories;
using BPApi.Domain.Dtos;
using BPApi.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BPApi.Application.Features.Queries.GetSites
{
    public sealed class GetSitesQueryHandler : BaseHandler<GetSitesQueryRequest, GetSitesQueryResponse>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IPumpRepository _pumpRepository;
        private readonly IMapper _mapper;
        private readonly IDistanceCalculator _distanceCalculator;

        public GetSitesQueryHandler(
            IMapper mapper,
            ISiteRepository siteRepository,
            IPumpRepository pumpRepository,
            IDistanceCalculator distanceCalculator,
            AbstractValidator<GetSitesQueryRequest> requestValidator
        ) : base(mapper, requestValidator: requestValidator)
        {
            _mapper = mapper;
            _siteRepository = siteRepository;
            _pumpRepository = pumpRepository;
            _distanceCalculator = distanceCalculator;
        }

        public override async Task<GetSitesQueryResponse> HandleAsync(GetSitesQueryRequest request, CancellationToken cancellationToken)
        {
            var sites = await _siteRepository.GetAll();

            var filteredSites = FilterSites(request, sites);

            if (filteredSites.Count > request.ItemCount)
            {
                filteredSites = filteredSites.Take(request.ItemCount).ToList();
            }

            return await MapResult(filteredSites, request.Latidute, request.Longitude);
        }

        private IList<Site> FilterSites(GetSitesQueryRequest request, IList<Site> sites)
        {
            var filteredSites = sites;

            if (!string.IsNullOrEmpty(request.SiteName))
            {
                filteredSites = FilterSitesBySiteName(request.SiteName, filteredSites);
            }

            if (request.Latidute != 0 && request.Longitude != 0)
            {
                filteredSites = FilterSitesByLocation(request, filteredSites);
            }

            return filteredSites.Take(request.ItemCount).ToList();
        }

        private List<Site> FilterSitesBySiteName(string siteName, IList<Site> filteredSites)
        {
            return filteredSites.Where(site => site.SiteName.Contains(siteName)).ToList();
        }

        private List<Site> FilterSitesByLocation(GetSitesQueryRequest request, IList<Site> filteredSites)
        {
            return filteredSites.OrderBy(x => Math.Pow((request.Latidute - x.Latitude), 2) + Math.Pow((request.Longitude - x.Longitude), 2)).Take(request.ItemCount).ToList();
        }

        private async Task<GetSitesQueryResponse> MapResult(IList<Site> sites, double userLatitude, double userLongitude)
        {
            var response = new GetSitesQueryResponse
            {
                Sites = new List<SiteDto>(sites.Count)
            };

            foreach (var site in sites)
            {
                var siteDto = _mapper.Map<SiteDto>(site);
                

                siteDto.Distance = _distanceCalculator.CalculateDistance(userLatitude, userLongitude, site.Latitude, site.Longitude);
                siteDto.Pumps = await MapPumps();

                response.Sites.Add(siteDto);
            }

            return response;
        }

        private async Task<List<PumpDto>> MapPumps()
        {
            var pumps = await _pumpRepository.GetPumpsBySiteCode();
            var pumpsDto = new List<PumpDto>(); 

            foreach(var pump in pumps)
            {
                var pumpDto = _mapper.Map<PumpDto>(pump);

                pumpDto.Type = PumpUtilities.GetPumpType(pump.Type);

                pumpsDto.Add(pumpDto);
            }

            return pumpsDto;
        }
    }
}
