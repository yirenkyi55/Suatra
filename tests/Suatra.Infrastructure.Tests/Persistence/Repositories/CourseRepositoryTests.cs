using Microsoft.EntityFrameworkCore;
using Shouldly;
using Suatra.Domain.Entities;
using Suatra.Fixtures;
using Suatra.Infrastructure.Persistence.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Suatra.Fixtures.Factories;
using Xunit;

namespace Suatra.Infrastructure.Tests.Persistence.Repositories
{
    public class CourseRepositoryTests : IClassFixture<ApplicationDbContextFactory>
    {
        private readonly TestApplicationDbContext _context;
        private readonly CourseRepository _sut;
        public CourseRepositoryTests(ApplicationDbContextFactory contextFactory)
        {
            _context = contextFactory.Context;
            _sut = new CourseRepository(_context);

        }

        [Fact]
        public async Task GetAll_ShouldGetAllCourses()
        {
            var results = await _sut.GetAllAsync();
            results.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Add_ShouldAddCourse()
        {
            var course = new Course
            {
                Name = "React, Getting Started",
                About = "The right course for every one",
                Description = "This course teaches you all what you need",
                TopicId = Guid.Parse("1e7dc72f-3336-4b5d-b429-b68be7e26c69"),
                Expectations = "Students will be abreast with React",
                IntendedAudience = "All Students willing to learn",
                Level = Domain.Enums.CourseLevel.All

            };

             _sut.Add(course);
            await _sut.UnitOfWork.SaveChangesAsync();

            await _context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id)
                  .ShouldNotBeNull();
        }

        [Theory]
        [LoadData("course")]
        public async Task GetById_ShouldGetACourse(Course course)
        {
            var result = await _sut.GetByIdAsync(course.Id);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(course.Id);
        }

        [Theory]
        [LoadData("course")]
        public async Task Update_ShouldUpdateACourse(Course course)
        {
            course.Name = "Updated Course Name";

            _sut.Update(course);

            await _sut.UnitOfWork.SaveChangesAsync();

            _context.Courses.FirstOrDefault(c => c.Id == course.Id)?.Name.ShouldBe(course.Name);
        }

        [Theory]
        [LoadData("course")]
        public async Task Delete_ShouldDeleteCourse(Course course)
        {
            // Retrieve the course and delete it
            var courseFromDb = await _sut.GetByIdAsync(course.Id);
            _sut.Remove(courseFromDb);
            await _sut.UnitOfWork.SaveChangesAsync();

            _context.Courses.FirstOrDefault(c => c.Id == course.Id).ShouldBeNull();
        }


    }
}
