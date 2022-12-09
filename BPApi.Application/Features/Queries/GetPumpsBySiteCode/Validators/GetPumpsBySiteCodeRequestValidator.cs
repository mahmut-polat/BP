using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Application.Features.Queries.GetPumpsBySiteCode.Validators
{
    public class GetPumpsBySiteCodeRequestValidator : AbstractValidator<GetPumpsBySiteCodeQueryRequest>
    {
        public GetPumpsBySiteCodeRequestValidator()
        {
            RuleFor(x => x.SiteCode).NotEmpty().WithMessage(Constants.NOT_EMPTY_SITE_CODE_ERROR_TEXT);
        }
    }
}
