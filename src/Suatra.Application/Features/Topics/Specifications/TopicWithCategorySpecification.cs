using System;
using Microsoft.EntityFrameworkCore;
using Suatra.Application.Common.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Topics.Specifications
{
    public class TopicWithCategorySpecification: BaseSpecification<Topic>
    {
        public TopicWithCategorySpecification()
        {
           AddIncludes();
        }

        public TopicWithCategorySpecification(Guid topicId): base(t=>t.Id == topicId)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(q=>q.Include(t=>t.Category));
        }
    }
}