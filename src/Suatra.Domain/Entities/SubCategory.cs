using System;
using System.Collections.Generic;

using Suatra.Domain.Common;

namespace Suatra.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
     
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}