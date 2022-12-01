using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Topics.Dto.Responses;
using Suatra.Application.Features.Topics.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Topics.Queries.GetTopics
{
    public class GetTopicsQuery: IRequest<IReadOnlyList<TopicResponse>>
    {
        
    }

    
    public class GetTopicsQueryHandler : IRequestHandler<GetTopicsQuery, IReadOnlyList<TopicResponse>>
    {
        private readonly IGenericRepository<Topic> _topicRepository;
        private readonly IMapper _mapper;

        public GetTopicsQueryHandler(IGenericRepository<Topic> topicRepository,IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<TopicResponse>> Handle(GetTopicsQuery request, CancellationToken cancellationToken)
        {
            var spec = new TopicWithSubCategorySpecification();

            var topics = await _topicRepository.GetAllWithSpec(spec);

            return _mapper.Map<IReadOnlyList<TopicResponse>>(topics);
        }
    }
}