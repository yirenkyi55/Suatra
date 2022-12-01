using AutoMapper;

using Suatra.Application.Features.Categories.Dto.Responses;
using Suatra.Application.Features.SubCategories.Dto.Requests;
using Suatra.Application.Features.SubCategories.Dto.Responses;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.SubCategories
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<CreateSubCategoryRequest, SubCategory>();
            CreateMap<SubCategory, SubCategoryResponse>();
        }
    }
}