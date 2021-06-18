using Suatra.Domain.Enums;
using System;

namespace Suatra.Application.Features.Courses.Dto.Requests
{
    public class CreateCourseRequest
    {
        public string Name { get; set; }

        public string About { get; set; }

        public string Description { get; set; }

        public string Expectations { get; set; }
        

        public string Requirements { get; set; }

        public string IntendedAudience { get; set; }

        public CourseLevel Level { get; set; }
        
        public Guid TopicId { get; set; }
    }
}
