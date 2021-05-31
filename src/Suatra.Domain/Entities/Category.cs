using Suatra.Domain.Common;
using System.Collections.Generic;

namespace Suatra.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Topics = new HashSet<Topic>();
        }
        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
