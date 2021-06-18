using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Courses.Dto.Requests;
using Suatra.Application.Features.Courses.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand: IRequest<CourseResponse>
    {
        public Guid CourseId { get; set; }
        public CreateCourseRequest UpdateCourseRequest { get; set; }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, CourseResponse>
    {
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(IGenericRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        
        public async Task<CourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var courseEntity = await _courseRepository.GetByIdAsync(request.CourseId);

            var course = _mapper.Map(request.UpdateCourseRequest, courseEntity);

            _courseRepository.Update(course);

            await _courseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CourseResponse>(course);
        }
    }
}