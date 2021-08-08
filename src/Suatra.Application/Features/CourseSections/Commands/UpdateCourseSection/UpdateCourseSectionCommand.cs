using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.CourseSections.Dto.Requests;
using Suatra.Application.Features.CourseSections.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.CourseSections.Commands.UpdateCourseSection
{
    public class UpdateCourseSectionCommand: IRequest<CourseSectionResponse>
    {
        public Guid SectionId { get; set; }

        public CreateSectionRequest UpdateSectionRequest { get; set; }
    }

    public class UpdateCourseSectionCommandHandler : IRequestHandler<UpdateCourseSectionCommand, CourseSectionResponse>
    {
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IGenericRepository<CourseSection> _courseSectionRepository;
        private readonly IMapper _mapper;

        public UpdateCourseSectionCommandHandler(
            IGenericRepository<Course> courseRepository, 
            IGenericRepository<CourseSection> courseSectionRepository, 
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _courseSectionRepository = courseSectionRepository;
            _mapper = mapper;
        }
        public async Task<CourseSectionResponse> Handle(UpdateCourseSectionCommand request, CancellationToken cancellationToken)
        {
            var courseSection = await _courseSectionRepository.GetByIdAsync(request.SectionId);

            _mapper.Map(request.UpdateSectionRequest, courseSection);

            _courseSectionRepository.Update(courseSection);

            await _courseSectionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CourseSectionResponse>(courseSection);
        }
    }
}