using System;

namespace Suatra.Application.Features.Topics.Dto.Requests
{
    public class CreateTopicRequest
    {
        public string Name { get; set; }

        public Guid SubCategoryId { get; set; }
    }

   
}
