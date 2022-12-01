using System;
using System.Collections.Generic;

using Suatra.Domain.Common;

namespace Suatra.Domain.Entities
{
    public class CourseSection : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int Order { get; set; }

        public virtual ICollection<SectionContent> SectionContents { get; set; }
    }
}