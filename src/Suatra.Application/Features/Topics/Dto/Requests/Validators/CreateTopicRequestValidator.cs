using FluentValidation;

namespace Suatra.Application.Features.Topics.Dto.Requests.Validators
{
    public class CreateTopicRequestValidator : AbstractValidator<CreateTopicRequest>
    {
        public CreateTopicRequestValidator()
        {
            RuleFor(x => x.SubCategoryId).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();
        }
    }
}