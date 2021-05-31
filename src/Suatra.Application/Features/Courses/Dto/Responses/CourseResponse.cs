using System;

namespace Suatra.Application.Features.Courses.Dto.Responses
{
    public class CourseResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public string Description { get; set; }

        public string Expectations { get; set; }

        public string Requirements { get; set; }

        public string IntendedAudience { get; set; }

        public double Duration { get; set; }

        public string CoverPhotoUri { get; set; }

        public string CoverVideoUri { get; set; }


    }
}
