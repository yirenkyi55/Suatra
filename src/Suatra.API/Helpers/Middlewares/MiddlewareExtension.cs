using Microsoft.AspNetCore.Builder;

namespace Suatra.API.Helpers.Middlewares
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddlewareHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
