using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Courses.Dto.Requests;
using Suatra.Application.Features.Courses.Dto.Responses;
using Suatra.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Domain.Enums;

namespace Suatra.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<CourseResponse>
    {
        public CreateCourseRequest CreateCourseRequest { get; set; }
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserService _currentUserService;

        public CreateCourseCommandHandler(
            IMapper mapper,
            IGenericRepository<Course> courseRepository,
            IIdentityService identityService,
            ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _identityService = identityService;
            _currentUserService = currentUserService;
        }

        public async Task<CourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            // map the request to a course entity
            var courseEntity = _mapper.Map<Course>(request.CreateCourseRequest);
            courseEntity.CourseStatus = CourseStatus.InProgress;
            var user = await _identityService.FindUserByEmailAsync(_currentUserService.GetLoggedInUserEmail());
            if (user == null)
            {
                throw new BadRequestException("Account does not exists");
            }
            courseEntity.Author = user;
            
            // Create the course, using the repository
            var course =  _courseRepository.Add(courseEntity);
            await _courseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            // Return a course response Dto from the course
            return _mapper.Map<CourseResponse>(course);
        }
    }
}
