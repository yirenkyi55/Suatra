using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Suatra.Application.Features.Categories.Dto.Responses;
using Suatra.Application.Features.SubCategories.Commands.CreateSubCategory;
using Suatra.Application.Features.SubCategories.Dto.Requests;
using Suatra.Application.Features.SubCategories.Dto.Responses;
using Suatra.Application.Features.SubCategories.Queries.GetSubCategories;

namespace Suatra.API.Controllers
{
    [Route("api/v{version:apiVersion}/subcategories")]
    public class SubCategoriesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<SubCategoryResponse>>> GetAllSubCategories()
        {
            var results = await Mediator.Send(new GetSubCategoriesQuery());
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryResponse>> CreateSubCategory(CreateSubCategoryRequest request)
        {
            var result = await Mediator.Send(new CreateSubCategoryCommand { CreateCategoryRequest = request });

            return Ok(result);
        }
    }
}