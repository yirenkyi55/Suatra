using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Topics.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Topics.Queries.GetTopic
{
    public class GetTopicQuery: IRequest<TopicResponse>
    {
        public Guid TopicId { get; set; }
    }

    public class GetTopicQueryHandler : IRequestHandler<GetTopicQuery, TopicResponse>
    {
        private readonly IGenericRepository<Topic> _topicRepository;
        private readonly IMapper _mapper;

        public GetTopicQueryHandler(IGenericRepository<Topic> topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }
        public async Task<TopicResponse> Handle(GetTopicQuery request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetByIdAsync(request.TopicId);

            return _mapper.Map<TopicResponse>(topic);
        }
    }
}