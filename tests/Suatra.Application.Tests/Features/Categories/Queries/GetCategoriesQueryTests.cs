using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shouldly;
using Suatra.Application.Features.Categories.Dto;
using Suatra.Application.Features.Categories.Queries.GetCategories;
using Suatra.Domain.Entities;
using Suatra.Fixtures;
using Suatra.Fixtures.Factories;
using Suatra.Infrastructure.Persistence.Repositories;
using Xunit;

namespace Suatra.Application.Tests.Features.Categories.Queries
{
    public class GetCategoriesQueryTests: IClassFixture<ApplicationDbContextFactory>
    {
        private readonly GetCategoriesQueryHandler _sut;
        
        public GetCategoriesQueryTests(ApplicationDbContextFactory contextFactory)
        {
            var repository = new GenericRepository<Category>(contextFactory.Context);
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            var mapper = mappingConfiguration.CreateMapper();

            _sut = new GetCategoriesQueryHandler(mapper, repository);
        }

        [Fact]
        public async Task Handle_GetCategoriesShouldReturnCategories()
        {
            var results = await _sut.Handle(new GetCategoriesQuery(), CancellationToken.None);
            
            results.Count.ShouldBeGreaterThan(0);
        }
    }
}