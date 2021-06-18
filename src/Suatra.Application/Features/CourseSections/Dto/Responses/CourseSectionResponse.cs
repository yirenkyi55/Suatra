using System;
using Suatra.Application.Features.Courses.Dto.Responses;

namespace Suatra.Application.Features.CourseSections.Dto.Responses
{
    public class CourseSectionResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }
    }
}