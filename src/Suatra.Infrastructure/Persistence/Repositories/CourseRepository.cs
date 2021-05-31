using Suatra.Application.Contracts.Persistence;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
