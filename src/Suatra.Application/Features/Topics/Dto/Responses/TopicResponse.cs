using System;
using Suatra.Application.Features.Categories.Dto.Responses;

namespace Suatra.Application.Features.Topics.Dto.Responses
{
    public class TopicResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public CategoryResponse Category { get; set; }
    }
}
