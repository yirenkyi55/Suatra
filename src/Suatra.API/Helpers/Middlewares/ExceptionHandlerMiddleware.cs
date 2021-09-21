using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Suatra.Application.Common.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Suatra.API.Helpers.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger,
            IHostEnvironment hostEnvironment
            )
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {

                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context,
            Exception exception, ILogger<ExceptionHandlerMiddleware> logger)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var result = string.Empty;
            var details = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    logger.LogWarning(exception, $"**Validation Exception Occured.**{exception.Message}");
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    logger.LogWarning(exception, $"**BadRequest Exception Occured.**{exception.Message}");
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    logger.LogWarning(exception, $"**NotFound Exception Occured.**{exception.Message}");
                    break;
                case UnauthorizedException unauthorizedException:
                    httpStatusCode = HttpStatusCode.Unauthorized;
                    result = unauthorizedException.Message;
                    logger.LogWarning(exception, $"**Unauthorized Exception Occured.**{exception.Message}");
                    break;
                case Exception ex:
                    details = _hostEnvironment.IsDevelopment() ? ex.StackTrace : string.Empty;
                    result = ex.Message;
                    logger.LogError(exception, $"Internal Server Error Occured.!!{ex.Message}.| {ex.StackTrace}");
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            string response;
            if (details == string.Empty)
            {
                response = JsonConvert.SerializeObject(new
                {
                    errors = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = result,

                    }
                });
            }
            else
            {
                response = JsonConvert.SerializeObject(new
                {
                    errors = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = result,
                        details
                    }
                });
            }

            await context.Response.WriteAsync(response);
        }
    }
}
