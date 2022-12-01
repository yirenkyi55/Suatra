using System;
using Microsoft.EntityFrameworkCore;
using Suatra.Application.Common.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Topics.Specifications
{
    public class TopicWithSubCategorySpecification: BaseSpecification<Topic>
    {
        public TopicWithSubCategorySpecification()
        {
           AddIncludes();
        }

        public TopicWithSubCategorySpecification(Guid topicId): base(t=>t.Id == topicId)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(q=>q
                .Include(t=>t.SubCategory)
                .ThenInclude(s=>s.Category)
            );
        }
    }
}