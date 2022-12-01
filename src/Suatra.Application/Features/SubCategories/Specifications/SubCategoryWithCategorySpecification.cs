using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Suatra.Application.Common.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.SubCategories.Specifications
{
    public class SubCategoryWithCategorySpecification : BaseSpecification<SubCategory>
    {
        public SubCategoryWithCategorySpecification()
        {
            IncludeCategory();
        }

        private void IncludeCategory()
        {
            AddInclude(q => q.Include(c => c.Category));
        }
    }
}
