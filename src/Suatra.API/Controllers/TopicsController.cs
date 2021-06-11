using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suatra.Application.Features.Topics.Commands.CreateTopic;
using Suatra.Application.Features.Topics.Commands.UpdateTopic;
using Suatra.Application.Features.Topics.Dto.Requests;
using Suatra.Application.Features.Topics.Dto.Responses;
using Suatra.Application.Features.Topics.Queries.GetTopic;
using Suatra.Application.Features.Topics.Queries.GetTopics;

namespace Suatra.API.Controllers
{
    [Route("api/v{version:apiVersion}/topics")]
    public class TopicsController: BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TopicResponse>>> GetTopics()
        {
            var results = await Mediator.Send(new GetTopicsQuery());
            return Ok(results);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TopicResponse>> GetTopic(Guid id)
        {
            var result = await Mediator.Send(new GetTopicQuery{TopicId = id});

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<TopicResponse>> CreateTopic(CreateTopicRequest request)
        {
            var result = await Mediator.Send(new CreateTopicCommand {CreateTopicRequest = request});

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TopicResponse>> UpdateTopic(Guid id, CreateTopicRequest request)
        {
            var result = await Mediator.Send(new UpdateTopicCommand() {UpdateTopicRequest = request, TopicId = id});

            return Ok(result);
        }
    }
}