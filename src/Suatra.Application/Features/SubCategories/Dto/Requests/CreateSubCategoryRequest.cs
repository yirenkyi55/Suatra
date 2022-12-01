using System;

namespace Suatra.Application.Features.SubCategories.Dto.Requests
{
    public class CreateSubCategoryRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}