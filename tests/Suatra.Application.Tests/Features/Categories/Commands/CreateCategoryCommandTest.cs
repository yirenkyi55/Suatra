using AutoMapper;
using Shouldly;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Categories.Commands.CreateCategory;
using Suatra.Application.Features.Categories.Dto;
using Suatra.Application.Features.Categories.Dto.Requests;
using Suatra.Domain.Entities;
using Suatra.Fixtures;
using Suatra.Infrastructure.Persistence.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Suatra.Fixtures.Factories;
using Xunit;

namespace Suatra.Application.Tests.Features.Categories.Commands
{
    public class CreateCategoryCommandTest : IClassFixture<ApplicationDbContextFactory>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandTest(ApplicationDbContextFactory contextFactory)
        {
            _categoryRepository = new GenericRepository<Category>(contextFactory.Context);

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

        }

        [Fact]
        public async Task ValidCategory_ShouldCreateCategory()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _categoryRepository);
            var request = new CreateCategoryRequest { Name = "Parental Care" };

            var response = await handler.Handle(
                new CreateCategoryCommand { CreateCategoryRequest = request },
                CancellationToken.None);

            response.ShouldNotBeNull();
            response.Id.ShouldBeOfType<Guid>();
            response.Name.ShouldBe(request.Name);

        }
    }
}
