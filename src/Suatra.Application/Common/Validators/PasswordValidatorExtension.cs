using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Suatra.Application.Common.Validators
{
    public static class PasswordValidatorExtension
    {
        public static IRuleBuilder<T, string> Password<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            PasswordOptions passwordOptions)
        {
             ruleBuilder
                .NotEmpty()
                .MinimumLength(passwordOptions.RequiredLength)
                .WithMessage($"Password should have a minimum length of {passwordOptions.RequiredLength} characters")

                .Matches("[0-9]")
                .When(x => passwordOptions.RequireDigit, ApplyConditionTo.CurrentValidator)
                .WithMessage("Password must contain at least one numeric value")

                .Matches("[a-z]")
                .When(x => passwordOptions.RequireLowercase, ApplyConditionTo.CurrentValidator)
                .WithMessage("Password must contain at least one lower case letter")

                .Matches("[A-Z]")
                .When(x => passwordOptions.RequireUppercase, ApplyConditionTo.CurrentValidator)
                .WithMessage("Password must contain at least one upper case letter")

                .Matches("[^a-zA-Z0-9]")
                .When(x => passwordOptions.RequireNonAlphanumeric, ApplyConditionTo.CurrentValidator)
                .WithMessage("Password should contain at least one non alphanumeric character");

             return ruleBuilder;
        }
    }
}