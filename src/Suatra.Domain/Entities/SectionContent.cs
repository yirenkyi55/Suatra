using Suatra.Domain.Common;
using Suatra.Domain.Enums;
using System;

namespace Suatra.Domain.Entities
{
    public class SectionContent : BaseEntity
    {
        public string Name { get; set; }

        public ContentType ContentType { get; set; }

        public string ContentUri { get; set; }

        public double Duration { get; set; }

        public int Order { get; set; }

        public Guid CourseSectionId { get; set; }

        public virtual CourseSection CourseSection { get; set; }
    }
}
