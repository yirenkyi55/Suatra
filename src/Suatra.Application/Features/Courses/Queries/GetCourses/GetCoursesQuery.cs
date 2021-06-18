using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Courses.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Courses.Queries.GetCourses
{
    public class GetCoursesQuery: IRequest<IReadOnlyList<CourseResponse>>
    {
        
    }

    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IReadOnlyList<CourseResponse>>
    {
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(IGenericRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<CourseResponse>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<CourseResponse>>(courses);
        }
    }
}