using Suatra.Domain.Common;
using System;

namespace Suatra.Domain.Entities
{
    public class CourseAuthor : BaseEntity
    {
        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
