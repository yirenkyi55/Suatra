using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Features.Categories.Dto.Requests;
using Suatra.Application.Features.Categories.Dto.Responses;
using Suatra.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Suatra.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryResponse>
    {
        public CreateCategoryRequest CreateCategoryRequest { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, IGenericRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CreateCategoryRequest);

             _categoryRepository.Add(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryResponse>(category);
        }
    }
}
