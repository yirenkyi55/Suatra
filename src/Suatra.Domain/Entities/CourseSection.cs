using Suatra.Domain.Common;
using System;
using System.Collections.Generic;

namespace Suatra.Domain.Entities
{
    public class CourseSection : BaseEntity
    {
        public CourseSection()
        {
            SectionContents = new HashSet<SectionContent>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int Order { get; set; }

        public virtual ICollection<SectionContent> SectionContents { get; set; }
    }
}
