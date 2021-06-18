using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Domain.Entities;

namespace Suatra.API.Helpers.Filters
{
    public class CourseExistsAttribute: TypeFilterAttribute
    {
        public CourseExistsAttribute() : base(typeof(CourseExistsFilterImplementation))
        {
        }
    }

    public class CourseExistsFilterImplementation : IAsyncActionFilter
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public CourseExistsFilterImplementation(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments["id"] is not Guid id)
            {
                context.Result = new BadRequestResult();
                return;
            }

            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                context.Result = new NotFoundObjectResult(new
                {
                    errors = new
                    {
                        statusCode = (int)HttpStatusCode.NotFound,
                        message = $"course with id {id} not exist.",

                    }
                });
                
                return;
            }

            await next();
        }
    }
}