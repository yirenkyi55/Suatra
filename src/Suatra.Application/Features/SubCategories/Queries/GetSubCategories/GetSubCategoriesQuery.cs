using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.SubCategories.Dto.Responses;
using Suatra.Application.Features.SubCategories.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.SubCategories.Queries.GetSubCategories;

public class GetSubCategoriesQuery : IRequest<List<SubCategoryResponse>>
{
}

public class GetCategoriesQueryHandler : IRequestHandler<GetSubCategoriesQuery, List<SubCategoryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<SubCategory> _categoryRepository;

    public GetCategoriesQueryHandler(IMapper mapper, IGenericRepository<SubCategory> categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<SubCategoryResponse>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var spec = new SubCategoryWithCategorySpecification();

        var categories = await _categoryRepository.GetAllWithSpec(spec);

        return _mapper.Map<List<SubCategoryResponse>>(categories);
    }
}