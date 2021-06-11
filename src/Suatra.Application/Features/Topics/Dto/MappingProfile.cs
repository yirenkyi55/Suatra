using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suatra.Application.Features.Topics.Dto.Requests;
using Suatra.Application.Features.Topics.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Topics.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Topic, TopicResponse>();
            CreateMap<CreateTopicRequest, Topic>();
        }
    }
}
