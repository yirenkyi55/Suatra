using System;
using Shouldly;
using Suatra.Application.Features.Categories.Specifications;
using Suatra.Domain.Entities;
using Suatra.Fixtures;
using Suatra.Infrastructure.Persistence.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Suatra.Fixtures.Factories;
using Xunit;

namespace Suatra.Infrastructure.Tests.Persistence.Repositories
{
    public class CategoryRepositoryTest : IClassFixture<ApplicationDbContextFactory>
    {
        private readonly TestApplicationDbContext _context;
        private readonly GenericRepository<Category> _sut;
        public CategoryRepositoryTest(ApplicationDbContextFactory contextFactory)
        {
            _context = contextFactory.Context;
            _sut = new GenericRepository<Category>(_context);
        }

        [Fact]
        public async Task GetAll_ShouldGetAllCategories()
        {
            var results = await _sut.GetAllAsync();

            results.Count.ShouldBeGreaterThan(0);
        }

        [Theory]
        [LoadData("category")]
        public async Task GetByName_ShouldGetCategoryByName(Category category)
        {
            var spec = new CategoryByNameSpecification(category.Name);
            var result = await _sut.GetEntityWithSpecAsync(spec);

            result.ShouldNotBeNull();
            result.Name.ShouldBe(category.Name);
        }

        [Theory]
        [LoadData("category")]
        public async Task GetById_ShouldGetCategoryById(Category category)
        {
            var result = await _sut.GetByIdAsync(category.Id);
            result.ShouldNotBeNull();
            result.Id.ShouldBe(category.Id);
        }

        [Theory]
        [LoadData("category")]
        public async Task Update_ShouldUpdateCategory(Category category)
        {
            var result = await _sut.GetByIdAsync(category.Id);
            result.Name = "Updated Category";
            _sut.Update(result);
            await _sut.UnitOfWork.SaveChangesAsync();

            _context.Categories.FirstOrDefault(c => c.Id == category.Id)
                ?.Name.ShouldBe(result.Name);
        }

        [Fact]
        public async Task Add_ShouldAddNewCategory()
        {
            var category = new Category
            {
                Name = "Life Hacks"
            };

             _sut.Add(category);
            await _sut.UnitOfWork.SaveChangesAsync();

            _context.Categories.FirstOrDefault(c => c.Id == category.Id)
                .ShouldNotBeNull();
        }

        [Theory]
        [InlineData("84905e7f-3c57-42fb-9501-70b6d706aae4")]
        public async Task SoftDelete_ShouldRemoveCategoryTemporary(string categoryId)
        {
            var category =await _sut.GetByIdAsync(Guid.Parse(categoryId));
            await _sut.SoftDeleteAsync(category);
            await _sut.UnitOfWork.SaveChangesAsync();
            
            _context.Categories
                .FirstOrDefault(c=>c.Id ==category.Id)
                ?.IsInActive.ShouldBeTrue();
        }
        

    }
}
