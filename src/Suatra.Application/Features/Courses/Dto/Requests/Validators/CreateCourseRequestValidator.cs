using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Courses.Dto.Requests.Validators
{
    public class CreateCourseRequestValidator: AbstractValidator<CreateCourseRequest>
    {
        private readonly IGenericRepository<Topic> _topicRepository;

        public CreateCourseRequestValidator(IGenericRepository<Topic> topicRepository)
        {
            _topicRepository = topicRepository;
            
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.About).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Expectations).NotEmpty();
            RuleFor(x => x.IntendedAudience).NotEmpty();
            RuleFor(x => x.TopicId)
                .NotEmpty()
                .MustAsync(TopicShouldExists)
                .WithMessage("Topic does not exists");
            RuleFor(x => x.Level).IsInEnum().NotNull();
        }

        private async Task<bool> TopicShouldExists(Guid topicId, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetByIdAsync(topicId);
            return topic != null;
        }
    }
}