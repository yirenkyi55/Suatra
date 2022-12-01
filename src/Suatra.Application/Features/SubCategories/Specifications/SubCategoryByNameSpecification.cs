using System;

using Suatra.Application.Common.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.SubCategories.Specifications
{
    public class SubCategoryByNameSpecification : BaseSpecification<SubCategory>
    {
        public SubCategoryByNameSpecification(string name)
            : base(cat => cat.Name.ToLower() == name.ToLower())
        {
        }
    }
}