﻿using AutoMapper;
using MediatR;
using Suatra.Application.Contracts.Persistence;
using Suatra.Application.Features.Courses.Dto.Requests;
using Suatra.Application.Features.Courses.Dto.Responses;
using Suatra.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Suatra.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<CourseResponse>
    {
        public CreateCourseRequest CreateCourseRequest { get; set; }
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<CourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            // map the request to a course entity
            var courseEntity = _mapper.Map<Course>(request.CreateCourseRequest);


            // Create the course, using the repository
            var course = await _courseRepository.AddAsync(courseEntity);
            await _courseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            // Return a course response Dto from the course
            return _mapper.Map<CourseResponse>(course);
        }
    }
}
