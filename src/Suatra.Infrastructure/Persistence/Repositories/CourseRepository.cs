using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
