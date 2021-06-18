using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.CourseSections.Dto.Requests.Validators
{
    public class CreateSectionRequestValidator: AbstractValidator<CreateSectionRequest>
    {

        public CreateSectionRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).MaximumLength(500);
        }

        
    }
}