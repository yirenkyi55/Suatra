using Suatra.Domain.Common;
using System;
using System.Collections.Generic;

namespace Suatra.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public Topic()
        {
            Courses = new HashSet<Course>();
        }
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
