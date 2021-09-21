using FluentValidation.TestHelper;
using Moq;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Specifications;
using Suatra.Application.Features.Categories.Dto.Requests;
using Suatra.Application.Features.Categories.Dto.Requests.Validators;
using Suatra.Domain.Entities;
using Xunit;

namespace Suatra.Application.Tests.Features.Categories.Validators
{
    public class CreateCategoryRequestValidatorTest
    {
        private readonly CreateCategoryRequestValidator _validator;
        private readonly Mock<IGenericRepository<Category>> _categoryRepositoryMock;

        public CreateCategoryRequestValidatorTest()
        {
            _categoryRepositoryMock = new Mock<IGenericRepository<Category>>();
            _categoryRepositoryMock.Setup(x => x.GetEntityWithSpecAsync(It.IsAny<BaseSpecification<Category>>()))
                .ReturnsAsync(() => null);

            _validator = new CreateCategoryRequestValidator(_categoryRepositoryMock.Object);
        }

        [Fact]
        public void Should_Have_Error_When_Name_IsNull()
        {
            var request = new CreateCategoryRequest();
            _validator.ShouldHaveValidationErrorFor(x => x.Name, request);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Already_Exists()
        {
            _categoryRepositoryMock.Setup(x => x.GetEntityWithSpecAsync(It.IsAny<BaseSpecification<Category>>()))
             .ReturnsAsync(() => new Category());

            var request = new CreateCategoryRequest { Name = "Programming" };
            _validator.ShouldHaveValidationErrorFor(x => x.Name, request);
        }
    }
}
