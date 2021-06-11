using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Topics.Dto.Requests;
using Suatra.Application.Features.Topics.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Topics.Commands.CreateTopic
{
    public class CreateTopicCommand : IRequest<TopicResponse>
    {
        public CreateTopicRequest CreateTopicRequest { get; set; }
    }
    
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, TopicResponse>
    {
        private readonly IGenericRepository<Topic> _topicRepository;
        private readonly IMapper _mapper;

        public CreateTopicCommandHandler(IGenericRepository<Topic> topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }
        
        public async Task<TopicResponse> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = _mapper.Map<Topic>(request.CreateTopicRequest);

           await _topicRepository.AddAsync(topic);

           await _topicRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

           return _mapper.Map<TopicResponse>(topic);
        }
    }
}
