using FluentValidation;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Categories.Specifications;
using Suatra.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Suatra.Application.Features.Categories.Dto.Requests.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CreateCategoryRequestValidator(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name).NotEmpty().MaximumLength(200)
                .MustAsync(UniqueCategory).WithMessage("Category already exists");

        }

        private async Task<bool> UniqueCategory(string categoryName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return false;
            }

            var spec = new CategoryByNameSpecification(categoryName);

            var category = await _categoryRepository.GetEntityWithSpecAsync(spec);

            return category == null;
        }
    }
}
