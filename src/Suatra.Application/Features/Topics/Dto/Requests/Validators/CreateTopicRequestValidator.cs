using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Categories.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Topics.Dto.Requests.Validators
{
    public class CreateTopicRequestValidator: AbstractValidator<CreateTopicRequest>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CreateTopicRequestValidator(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.CategoryId).NotEmpty()
                .MustAsync(CategoryExists)
                .WithMessage("Category does not exists");
            RuleFor(x => x.Name).NotEmpty()
                .MustAsync(NameShouldBeUniqueForCategory).WithMessage("Topic Already exists for category");
        }

        private async Task<bool> NameShouldBeUniqueForCategory(CreateTopicRequest request,
            string topicName, CancellationToken arg3)
        {
            var spec = new CategoryWithTopicSpecification(request.CategoryId);
            
            var category = await _categoryRepository.GetEntityWithSpecAsync(spec);

            var topic = category.Topics.FirstOrDefault(t => t.Name.ToLower() == topicName.ToLower());

            return topic == null;
        }

        private async Task<bool> CategoryExists(Guid categoryId, CancellationToken cancellationToken)
        {
            var category =await _categoryRepository.GetByIdAsync(categoryId);
            return category != null;
        }
    }
}