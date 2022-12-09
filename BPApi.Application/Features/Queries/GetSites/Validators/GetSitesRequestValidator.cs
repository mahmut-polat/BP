using BPApi.Application.Features.Queries.GetAllPumps;
using FluentValidation;

namespace BPApi.Application.Features.Queries.GetSites.Validators
{
    public class GetSitesRequestValidator : AbstractValidator<GetSitesQueryRequest>
    {
        public GetSitesRequestValidator()
        {
            RuleFor(x => x.ItemCount).NotEmpty().WithMessage(Constants.NOT_EMPTY_ITEM_COUNT_ERROR_TEXT);
            RuleFor(x => x.Latidute).NotEmpty().When(x => x.Longitude != 0).WithMessage(Constants.NOT_EMPTY_LATITUDE_ERROR_TEXT);
            RuleFor(x => x.Longitude).NotEmpty().When(x => x.Latidute != 0).WithMessage(Constants.NOT_EMPTY_LONGITUDE_ERROR_TEXT);
        }
    }
}
