using FluentValidation;

namespace Suatra.Application.Features.Auth.Dto.Requests.Validators
{
    public class ResetPasswordRequestValidator: AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Token).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}