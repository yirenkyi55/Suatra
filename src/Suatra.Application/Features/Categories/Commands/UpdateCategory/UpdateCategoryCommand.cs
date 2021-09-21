using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.Categories.Dto.Requests;
using Suatra.Application.Features.Categories.Dto.Responses;
using Suatra.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Suatra.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CategoryResponse>
    {
        public Guid Id { get; set; }

        public CreateCategoryRequest UpdateCategoryRequest { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryFromRepo = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryFromRepo == null)
            {
                throw new NotFoundException("category", "record");
            }

            _mapper.Map(request.UpdateCategoryRequest, categoryFromRepo);

            _categoryRepository.Update(categoryFromRepo);

            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryResponse>(categoryFromRepo);

        }
    }
}
