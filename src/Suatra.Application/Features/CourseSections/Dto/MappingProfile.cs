using AutoMapper;
using Suatra.Application.Features.CourseSections.Dto.Requests;
using Suatra.Application.Features.CourseSections.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.CourseSections.Dto
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseSection, CourseSectionResponse>();
            CreateMap<CreateSectionRequest, CourseSection>();
        }
    }
}