using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Topics.Dto.Requests;
using Suatra.Application.Features.Topics.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Topics.Commands.UpdateTopic
{
    public class UpdateTopicCommand: IRequest<TopicResponse>
    {
        public Guid TopicId { get; set; }

        public CreateTopicRequest UpdateTopicRequest { get; set; }
    }

    public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, TopicResponse>
    {
        private readonly IGenericRepository<Topic> _topicRepository;
        private readonly IMapper _mapper;

        public UpdateTopicCommandHandler(IGenericRepository<Topic> topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }
        
        public async Task<TopicResponse> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetByIdAsync(request.TopicId);

            _mapper.Map(request.UpdateTopicRequest, topic);

            _topicRepository.Update(topic);

            await _topicRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TopicResponse>(topic);
        }
    }
}