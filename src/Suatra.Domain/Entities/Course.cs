using System;
using System.Collections.Generic;

using Suatra.Domain.Common;
using Suatra.Domain.Enums;

namespace Suatra.Domain.Entities
{
    public class Course : AuditableEntity
    {
        public string Name { get; set; }

        public string About { get; set; }

        public string Description { get; set; }

        public string Expectations { get; set; }

        public string Requirements { get; set; }

        public string IntendedAudience { get; set; }

        public double Duration { get; set; }

        public string CoverPhotoUri { get; set; }

        public string CoverVideoUri { get; set; }

        public CourseLevel Level { get; set; }

        public CourseStatus CourseStatus { get; set; }

        public CourseType CourseType { get; set; }

        public Guid TopicId { get; set; }

        public virtual Topic Topic { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<CourseSection> CourseSections { get; set; }
    }
}