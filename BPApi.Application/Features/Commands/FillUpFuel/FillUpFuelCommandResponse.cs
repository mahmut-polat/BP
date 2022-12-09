using BPApi.Domain.Common;
using BPApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Application.Features.Commands.FillUpFuel
{
    public class FillUpFuelCommandResponse : BaseResponse, IRequest
    {
        public string SiteCode { get; set; }
        public string PumpCode { get; set; }
        public PumpType PumpType { get; set; }
        public double RemainedLitres { get; set; }
        public double FuelAmount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
