using FluentValidation;

namespace Suatra.Application.Features.Auth.Dto.Requests.Validators
{
    public class ForgotPasswordRequestValidator: AbstractValidator<ForgotPasswordRequest>
    {
        public ForgotPasswordRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}