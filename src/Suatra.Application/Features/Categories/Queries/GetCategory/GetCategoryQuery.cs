using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.Categories.Dto.Responses;
using Suatra.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Suatra.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryResponse>
    {
        public Guid Id { get; }
        public GetCategoryQuery(Guid id)
        {
            Id = id;
        }

    }

    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryResponse>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundException("category", "record");
            }

            return _mapper.Map<CategoryResponse>(category);
        }
    }
}
