using FluentValidation;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Categories.Specifications;
using Suatra.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Suatra.Application.Common.Constants;

namespace Suatra.Application.Features.Categories.Dto.Requests.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CreateCategoryRequestValidator(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name).NotEmpty().MaximumLength(EntityConfigurationConstants.MaxLengthOf128)
                .Must(UniqueCategory).WithMessage("Category already exists");

        }

        private bool UniqueCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return false;
            }

            var spec = new CategoryByNameSpecification(categoryName);

            var category =  _categoryRepository.GetEntityWithSpecAsync(spec).Result;

            return category == null;
        }
    }
}
