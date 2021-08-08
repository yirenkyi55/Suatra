using FluentValidation;

namespace Suatra.Application.Features.Auth.Dto.Requests.Validators
{
    public class CreateAccountRequestValidator: AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(150);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(150);
            RuleFor(x => x.OtherName).MaximumLength(150);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}