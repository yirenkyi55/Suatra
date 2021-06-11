using AutoMapper;
using Suatra.Application.Features.Categories.Dto.Requests;
using Suatra.Application.Features.Categories.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Categories.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();
        }
    }
}
