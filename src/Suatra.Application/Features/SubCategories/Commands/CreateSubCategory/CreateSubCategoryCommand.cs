using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.SubCategories.Dto.Requests;
using Suatra.Application.Features.SubCategories.Dto.Responses;
using Suatra.Application.Features.SubCategories.Specifications;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.SubCategories.Commands.CreateSubCategory;

public class CreateSubCategoryCommand : IRequest<SubCategoryResponse>
{
    public CreateSubCategoryRequest CreateCategoryRequest { get; set; }
}

public class CreateSubCategoryCommandCommandHandler : IRequestHandler<CreateSubCategoryCommand, SubCategoryResponse>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<SubCategory> _subCategoryRepository;
    private readonly IGenericRepository<Category> _categoryRepository;

    public CreateSubCategoryCommandCommandHandler(IMapper mapper, IGenericRepository<SubCategory> subCategoryRepository, IGenericRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _subCategoryRepository = subCategoryRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<SubCategoryResponse> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CreateCategoryRequest.CategoryId);
        if (category == null)
        {
            throw new BadRequestException("Category does not exist");
        }

        var spec = new SubCategoryByNameSpecification(request.CreateCategoryRequest.Name);
        var dbSubCategory = await _subCategoryRepository.GetEntityWithSpecAsync(spec);
        if (dbSubCategory != null)
        {
            throw new BadRequestException("Sub category already exist");
        }

        var subCategory = _mapper.Map<SubCategory>(request.CreateCategoryRequest);
        _subCategoryRepository.Add(subCategory);

        await _subCategoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        subCategory.Category = category;

        return _mapper.Map<SubCategoryResponse>(subCategory);
    }
}