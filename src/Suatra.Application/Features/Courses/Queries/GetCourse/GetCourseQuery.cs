using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.Courses.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Courses.Queries.GetCourse
{
    public class GetCourseQuery: IRequest<CourseResponse>
    {
        public Guid CourseId { get; set; }
    }

    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseResponse>
    {
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseQueryHandler(IGenericRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        
        public async Task<CourseResponse> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var result = await _courseRepository.GetByIdAsync(request.CourseId);

          return _mapper.Map<CourseResponse>(result);
        }
    }
}