using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Categories.Dto.Responses;
using Suatra.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Suatra.Application.Features.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryResponse>>
    {
    }

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepository;

        public GetCategoriesQueryHandler(IMapper mapper, IGenericRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryResponse>>(categories);
        }
    }
}
