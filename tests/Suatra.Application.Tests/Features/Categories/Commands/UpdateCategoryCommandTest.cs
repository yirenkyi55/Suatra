using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.Categories.Commands.UpdateCategory;
using Suatra.Application.Features.Categories.Dto;
using Suatra.Application.Features.Categories.Dto.Requests;
using Suatra.Domain.Entities;
using Suatra.Fixtures;
using Suatra.Fixtures.Factories;
using Suatra.Infrastructure.Persistence.Repositories;
using Xunit;

namespace Suatra.Application.Tests.Features.Categories.Commands
{
    public class UpdateCategoryCommandTest: IClassFixture<ApplicationDbContextFactory>
    {
        private readonly UpdateCategoryCommandHandler _sut;
        
        public UpdateCategoryCommandTest(ApplicationDbContextFactory contextFactory)
        {
            var categoryRepository = new GenericRepository<Category>(contextFactory.Context);
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            var mapper = configurationProvider.CreateMapper();

            _sut = new UpdateCategoryCommandHandler(categoryRepository, mapper);
        }

        [Theory]
        [InlineData("54905e7f-3c57-42fb-9501-70b6d706aae9")]
        private  void Handle_ShouldThrowNotFoundExceptionWhenCategoryDoNotExists(string categoryId)
        {
            var request = new CreateCategoryRequest();
            var command = new UpdateCategoryCommand() {Id = Guid.Parse(categoryId), UpdateCategoryRequest = request};

            Should.Throw<NotFoundException>(async () => await _sut.Handle(
              command  ,
                CancellationToken.None
            ));
        }

        [Theory]
        [LoadData("category")]
        private async Task Handle_ShouldUpdateCategoryWhenRightDataIsSupplied(Category category)
        {
            var updateCategoryRequest = new CreateCategoryRequest() {Name = "Updated Category"};
            var request = new UpdateCategoryCommand {Id = category.Id, UpdateCategoryRequest = updateCategoryRequest};

            var result = await _sut.Handle(request, CancellationToken.None);
            result.Name.ShouldBe(updateCategoryRequest.Name);
        }
        
    }
}