using System;

using Microsoft.EntityFrameworkCore;

using Suatra.Application.Common.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.SubCategories.Specifications
{
    public class SubCategoryWithTopicSpecification : BaseSpecification<SubCategory>
    {
        
        public SubCategoryWithTopicSpecification(Guid subCategoryId) : base(c => c.Id == subCategoryId)
        {
            IncludeTopic();
        }

        private void IncludeTopic()
        {
            AddInclude(q => q.Include(c => c.Topics));
        }
    }
}