using System;
using System.Collections.Generic;

using Suatra.Domain.Common;

namespace Suatra.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }

        public Guid SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}