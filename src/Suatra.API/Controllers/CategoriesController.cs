using Microsoft.AspNetCore.Mvc;
using Suatra.Application.Features.Categories.Commands.CreateCategory;
using Suatra.Application.Features.Categories.Commands.UpdateCategory;
using Suatra.Application.Features.Categories.Dto.Requests;
using Suatra.Application.Features.Categories.Dto.Responses;
using Suatra.Application.Features.Categories.Queries.GetCategories;
using Suatra.Application.Features.Categories.Queries.GetCategory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Suatra.Application.Features.Categories.Commands.DeleteCategory;

namespace Suatra.API.Controllers
{
    [Route("api/v{version:apiVersion}/categories")]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<CategoryResponse>>> GetAllCategories()
        {
            var results = await Mediator.Send(new GetCategoriesQuery());
            return Ok(results);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryResponse>> GetCategoryById(Guid id)
        {
            var result = await Mediator.Send(new GetCategoryQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> CreateCategory(CreateCategoryRequest request)
        {
            var result = await Mediator.Send(new CreateCategoryCommand { CreateCategoryRequest = request });

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryResponse>> UpdateCategory(Guid id, CreateCategoryRequest request)
        {
            var result = await Mediator.Send(new UpdateCategoryCommand { Id = id, UpdateCategoryRequest = request });

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            await Mediator.Send(new DeleteCategoryCommand{Id = id});

            return NoContent();
        }
    }
}
