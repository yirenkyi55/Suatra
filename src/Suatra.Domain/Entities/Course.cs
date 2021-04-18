using Suatra.Domain.Common;
using Suatra.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Suatra.Domain.Entities
{
    public class Course : AuditableEntity
    {
        public Course()
        {
            CourseSections = new HashSet<CourseSection>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Expectations { get; set; }

        public string Requirements { get; set; }

        public double Duration { get; set; }

        public string CoverPhotoUri { get; set; }

        public string CoverVideoUri { get; set; }

        public CourseLevel Level { get; set; }

        public Guid TopicId { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual ICollection<CourseSection> CourseSections { get; set; }
    }
}
