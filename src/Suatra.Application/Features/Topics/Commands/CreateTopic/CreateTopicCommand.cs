using System;
using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.Topics.Dto.Requests;
using Suatra.Application.Features.Topics.Dto.Responses;
using Suatra.Domain.Entities;
using Suatra.Application.Features.SubCategories.Specifications;

namespace Suatra.Application.Features.Topics.Commands.CreateTopic
{
    public class CreateTopicCommand : IRequest<TopicResponse>
    {
        public CreateTopicRequest CreateTopicRequest { get; set; }
    }
    
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, TopicResponse>
    {
        private readonly IGenericRepository<Topic> _topicRepository;
        private  readonly  IGenericRepository<SubCategory> _subCategoryRepository;
        private readonly IMapper _mapper;

        public CreateTopicCommandHandler(IGenericRepository<Topic> topicRepository, IMapper mapper, IGenericRepository<SubCategory> subCategoryRepository)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
        }
        
        public async Task<TopicResponse> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var spec = new SubCategoryWithTopicSpecification(request.CreateTopicRequest.SubCategoryId);
            var subCategory = await _subCategoryRepository.GetEntityWithSpecAsync(spec);

            if (subCategory == null)
            {
                throw new BadRequestException("Sub category does not exist");
            }

            var topicAlreadyExist = subCategory.Topics.FirstOrDefault(x =>
                string.Equals(x.Name, request.CreateTopicRequest.Name, StringComparison.CurrentCultureIgnoreCase)) != null;

            if (topicAlreadyExist)
            {
                throw new BadRequestException("Topic already exist");
            }

            var topic = _mapper.Map<Topic>(request.CreateTopicRequest);

            topic.SubCategory = subCategory;

            _topicRepository.Add(topic);

           await _topicRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

           return _mapper.Map<TopicResponse>(topic);
        }
    }
}
