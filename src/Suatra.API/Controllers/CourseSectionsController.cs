using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suatra.API.Helpers.Filters;
using Suatra.Application.Features.CourseSections.Commands.CreateCourseSection;
using Suatra.Application.Features.CourseSections.Dto.Requests;
using Suatra.Application.Features.CourseSections.Dto.Responses;

namespace Suatra.API.Controllers
{
    [Route("api/v{version:apiVersion}/courses/{id:guid}/sections")]
    public class CourseSectionsController: BaseController
    {
        [HttpPost]
        [CourseExists]
        public async Task<ActionResult<CourseSectionResponse>> CreateCourseSection(Guid id, CreateSectionRequest request)
        {
            var result = await Mediator.Send(new CreateCourseSectionCommand
                {CourseId = id, CreateSectionRequest = request});
            return Ok(result);
        }
    }
}