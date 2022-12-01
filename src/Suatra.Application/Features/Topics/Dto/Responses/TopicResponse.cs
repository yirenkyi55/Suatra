using System;

using Suatra.Application.Features.SubCategories.Dto.Responses;

namespace Suatra.Application.Features.Topics.Dto.Responses
{
    public class TopicResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public SubCategoryResponse SubCategory { get; set; }
    }
}