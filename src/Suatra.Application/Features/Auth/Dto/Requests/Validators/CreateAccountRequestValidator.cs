using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Suatra.Application.Common.Validators;

namespace Suatra.Application.Features.Auth.Dto.Requests.Validators
{
    public class CreateAccountRequestValidator: AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountRequestValidator(PasswordOptions passwordOptions)
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(150);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(150);
            RuleFor(x => x.OtherName).MaximumLength(150);
            RuleFor(x => x.Password).Password(passwordOptions);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}