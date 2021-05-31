using AutoMapper;
using Suatra.Application.Features.Courses.Dto.Requests;
using Suatra.Application.Features.Courses.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Categories.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<Course, CourseResponse>();
        }
    }
}
