using FluentValidation;

namespace Suatra.Application.Features.Auth.Dto.Requests.Validators
{
    public class ActivateAccountRequestValidator: AbstractValidator<ActivateAccountRequest>
    {
        public ActivateAccountRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}