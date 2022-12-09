using AutoMapper;
using BPApi.Application.Extensions;
using BPApi.Domain.Common;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BPApi.Application.Interfaces.Features
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : BaseResponse
    {
        private readonly IMapper _mapper;
        private readonly AbstractValidator<TRequest> _requestValidator;
        private readonly AbstractValidator<TResponse> _responseValidator;

        public BaseHandler(
            IMapper mapper,
            AbstractValidator<TRequest> requestValidator = null,
            AbstractValidator<TResponse> responseValidator = null
        )
        {
            _mapper = mapper;   
            _requestValidator = requestValidator;   
            _responseValidator = responseValidator; 
        }

        public abstract Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var isRequestValidatorNotExists = _requestValidator.IsNullOrEmpty();
                var requestValidationResult = Validate(request);

                if (isRequestValidatorNotExists || requestValidationResult.IsValid)
                {
                    var response = await HandleAsync(request, cancellationToken);

                    var isResponseValidatorNotExists = _responseValidator.IsNullOrEmpty();
                    var responseValidationResult = Validate(response);

                    if(isResponseValidatorNotExists || responseValidationResult.IsValid)
                    {
                        return response;
                    }

                    return BuildErrorResponse(responseValidationResult);
                }

                return BuildErrorResponse(requestValidationResult);
            }
            catch(Exception ex)
            {
                var response = new BaseResponse();

                BuildFailedResponse((TResponse)response, ex);

                return (TResponse)response;
            }
        }

        protected void BuildFailedResponse(TResponse response, string errorMessage)
        {
            BuildFailedResponse(response, Constants.WARNING_TITLE, errorMessage);
        }

        private void BuildFailedResponse(TResponse response, Exception exception)
        {
            
            BuildFailedResponse(response, Constants.ERROR_TITLE, exception.Message);
        }

        private void BuildFailedResponse(TResponse response, string type, string message)
        {
            var errors = new List<Error>(1);
            var error = new Error(type, message);

            errors.Add(error);

            response.IsSuccessful = false;
            response.Errors = errors;
        }

        private ValidationResult Validate(TRequest request)
        {
            return _requestValidator.IsNullOrEmpty() ? null : _requestValidator.Validate(request);
        }

        private ValidationResult Validate(TResponse response)
        {
            return _responseValidator.IsNullOrEmpty() ? null : _responseValidator.Validate(response);
        }

        private TResponse BuildErrorResponse(ValidationResult result)
        {
            var response = new BaseResponse();
            var errors = GetErrorsIfExists(result);

            response.IsSuccessful = false;
            response.Errors = errors;

            var mapperResult = _mapper.Map<TResponse>(response);

            return mapperResult;
        }

        private IList<Error> GetErrorsIfExists(ValidationResult result)
        {
            if (result.IsValid)
            {
                return null;
            }

            var errors = new List<Error>();

            result.Errors.ForEach(e => errors.Add(new Error(Constants.WARNING_TITLE, e.ErrorMessage)));

            return errors;  
        }
    }
}
