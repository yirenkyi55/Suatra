using System.Collections.Generic;

using Suatra.Domain.Common;

namespace Suatra.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}