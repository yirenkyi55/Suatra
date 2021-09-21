using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Exceptions;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Categories.Commands.DeleteCategory
{

    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public DeleteCategoryCommandHandler(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundException("category", "entity");
            }

            await _categoryRepository.SoftDeleteAsync(category);

            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
