using System.Collections.Generic;
using System.Linq;
using System.Net;

using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Suatra.API.Extensions
{
    public static class ValidationResultExtension
    {
        //https://medium.com/cheranga/using-asynchronous-fluent-validations-in-asp-net-api-831710b0b9cd
        public static ProblemDetails ToProblemDetails(this IEnumerable<ValidationFailure> validationFailures)
        {
            var errors = validationFailures.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);

            var problemDetails = new ProblemDetails
            {
                Type = "ValidationError",
                Detail = "invalid request, please check the error list for more details",
                Status = (int)(HttpStatusCode.BadRequest),
                Title = "invalid request"
            };

            problemDetails.Extensions.Add("errors", errors);
            return problemDetails;
        }
    }
}
