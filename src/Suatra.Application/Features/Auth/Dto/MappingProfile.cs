using AutoMapper;
using Suatra.Application.Features.Auth.Dto.Requests;
using Suatra.Application.Features.Auth.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Auth.Dto
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AuthUserResponse>();
            CreateMap<CreateAccountRequest, User>();
        }
    }
}