using Suatra.Application.Common.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Categories.Specifications
{
    public class CategoryByNameSpecification : BaseSpecification<Category>
    {
        public CategoryByNameSpecification(string name)
            : base(cat => cat.Name.ToLower() == name.ToLower())
        {
        }
    }
}