using AutoMapper;
using BPApi.Application.Features.Commands.FillUpFuel;
using BPApi.Application.Features.Queries.GetAllPumps;
using BPApi.Application.Features.Queries.GetPumpsBySiteCode;
using BPApi.Domain.Common;
using BPApi.Domain.Dtos;
using BPApi.Domain.Entities;

namespace BPApi.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Site, SiteDto>();
            CreateMap<Pump, PumpDto>();
            CreateMap<BaseResponse, GetPumpsBySiteCodeQueryResponse>();
            CreateMap<BaseResponse, GetSitesQueryResponse>();
            CreateMap<BaseResponse, FillUpFuelCommandResponse>();
        }
    }
}
