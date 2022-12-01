using FluentValidation;

using Suatra.Application.Common.Constants;

namespace Suatra.Application.Features.SubCategories.Dto.Requests.Validators
{
    public class CreateSubCategoryRequestValidator : AbstractValidator<CreateSubCategoryRequest>
    {
        public CreateSubCategoryRequestValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(EntityConfigurationConstants.MaxLengthOf128);
        }
    }
}