using System;

using Suatra.Application.Features.Categories.Dto.Responses;

namespace Suatra.Application.Features.SubCategories.Dto.Responses
{
    public class SubCategoryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CategoryResponse Category { get; set; }
    }
}