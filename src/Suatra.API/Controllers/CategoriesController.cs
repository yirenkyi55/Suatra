using Microsoft.AspNetCore.Mvc;
using Suatra.Application.Features.Categories.Commands.CreateCategory;
using Suatra.Application.Features.Categories.Dto.Requests;
using Suatra.Application.Features.Categories.Dto.Responses;
using System.Threading.Tasks;

namespace Suatra.API.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> CreateCategory(CreateCategoryRequest request)
        {
            var result = await Mediator.Send(new CreateCategoryCommand { CreateCategoryRequest = request });

            return Ok(result);
        }
    }
}
