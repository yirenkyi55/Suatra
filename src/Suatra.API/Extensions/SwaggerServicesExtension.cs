using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace Suatra.API.Extensions
{
    public static class SwaggerServicesExtension
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            var apiVersionDesc = services.BuildServiceProvider()
                .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(c =>
            {
                foreach (var description in apiVersionDesc.ApiVersionDescriptions)
                {
                    c.SwaggerDoc($"SuatraApi{description.GroupName}", new OpenApiInfo
                    {
                        Title = "Suatra Api",
                        Version = description.ApiVersion.ToString(),
                        Description = "This API Provides end-points for interacting with Suatra App"
                    });

                    c.DocInclusionPredicate((docName, apiDesc) =>
                    {
                        var apiVersionModel = apiDesc.ActionDescriptor
                        .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);

                        if (apiVersionModel.DeclaredApiVersions.Any())
                        {
                            return apiVersionModel
                            .DeclaredApiVersions
                            .Any(version => $"SuatraApiv{version}" == docName);
                        }

                        return apiVersionModel
                        .ImplementedApiVersions
                        .Any(version => $"SuatraApiv{version}" == docName);
                    });
                }

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    foreach (var desc in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"/swagger/SuatraApi{desc.GroupName}/swagger.json",
                            desc.GroupName.ToUpperInvariant());
                    }
                });
            }

            return app;
        }

    }
}
