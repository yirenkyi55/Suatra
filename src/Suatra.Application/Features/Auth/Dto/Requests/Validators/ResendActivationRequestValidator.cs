using FluentValidation;

namespace Suatra.Application.Features.Auth.Dto.Requests.Validators
{
    public class ResendActivationRequestValidator: AbstractValidator<ResendActivationRequest>
    {
        public ResendActivationRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}