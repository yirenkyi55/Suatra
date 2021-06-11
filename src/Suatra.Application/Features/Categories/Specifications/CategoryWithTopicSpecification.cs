using System;
using Microsoft.EntityFrameworkCore;
using Suatra.Application.Common.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Categories.Specifications
{
    public class CategoryWithTopicSpecification: BaseSpecification<Category>
    {
        public CategoryWithTopicSpecification()
        {
           IncludeTopic();
        }

        
        public CategoryWithTopicSpecification(Guid categoryId):base(c=>c.Id == categoryId)
        {
                IncludeTopic();
        }

        private void IncludeTopic()
        {
            AddInclude(q=>q.Include(c=>c.Topics));
        }
    }
}