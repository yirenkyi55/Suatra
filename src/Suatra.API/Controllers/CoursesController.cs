using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suatra.API.Helpers.Filters;
using Suatra.Application.Features.Courses.Commands.CreateCourse;
using Suatra.Application.Features.Courses.Commands.UpdateCourse;
using Suatra.Application.Features.Courses.Dto.Requests;
using Suatra.Application.Features.Courses.Dto.Responses;
using Suatra.Application.Features.Courses.Queries.GetCourse;
using Suatra.Application.Features.Courses.Queries.GetCourses;

namespace Suatra.API.Controllers
{
    [Route("api/v{version:apiVersion}/courses")]
    public class CoursesController: BaseController
    {
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CourseResponse>>> GetCourses()
        {
            var courses = await Mediator.Send(new GetCoursesQuery());
            return Ok(courses);
        }

        [HttpGet("{id}", Name = nameof(GetCourse))]
        [CourseExists]
        public async Task<ActionResult<CourseResponse>> GetCourse(Guid id)
        {
            var course = await Mediator.Send(new GetCourseQuery() {CourseId = id});
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseResponse>> CreateCourse(CreateCourseRequest request, ApiVersion version)
        {
            var result = await Mediator.Send(new CreateCourseCommand() {CreateCourseRequest = request});

            return CreatedAtRoute(nameof(GetCourse),new{id=result.Id, version=version.ToString()},result);
        }

        [HttpPut("{id}")]
        [CourseExists]
        public async Task<ActionResult<CourseResponse>> UpdateCourse(CreateCourseRequest request, Guid id)
        {
            var result = await Mediator.Send(new UpdateCourseCommand() {UpdateCourseRequest = request, CourseId = id});

            return Ok(result);
        }
    }
}