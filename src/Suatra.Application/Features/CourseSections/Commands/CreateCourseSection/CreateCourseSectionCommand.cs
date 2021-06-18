using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.CourseSections.Dto.Requests;
using Suatra.Application.Features.CourseSections.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.CourseSections.Commands.CreateCourseSection
{
    public class CreateCourseSectionCommand: IRequest<CourseSectionResponse>
    {
        public Guid CourseId { get; set; }

        public CreateSectionRequest CreateSectionRequest { get; set; }
    }

    public class CreateCourseSectionCommandHandler : IRequestHandler<CreateCourseSectionCommand, CourseSectionResponse>
    {
        private readonly IGenericRepository<CourseSection> _courseSectionRepository;
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public CreateCourseSectionCommandHandler(
            IGenericRepository<CourseSection> courseSectionRepository, 
            IGenericRepository<Course> courseRepository,
            IMapper mapper)
        {
            _courseSectionRepository = courseSectionRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        
        public async Task<CourseSectionResponse> Handle(CreateCourseSectionCommand request, CancellationToken cancellationToken)
        {
            var sectionExists = _courseSectionRepository.GetAny(cs =>
                cs.CourseId == request.CourseId && cs.Name.ToLower() == request.CreateSectionRequest.Name.ToLower());

            if (sectionExists)
            {
                throw new BadRequestException("Section already exists for course");
            }
            
            var course = await _courseRepository.GetByIdAsync(request.CourseId);
            
            var courseSection = _mapper.Map<CourseSection>(request.CreateSectionRequest);
            courseSection.Course = course;

            var maximumOrder = await _courseSectionRepository.GetMaxEntity(x => x.Order);
            courseSection.Order = maximumOrder + 1;

           await _courseSectionRepository.AddAsync(courseSection);

           await _courseSectionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

           return _mapper.Map<CourseSectionResponse>(courseSection);
        }
    }
}