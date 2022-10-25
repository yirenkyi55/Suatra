
using Microsoft.AspNetCore.Builder;
using Suatra.API.Extensions;
using Suatra.API.Helpers.Middlewares;
using Suatra.Application;
using Suatra.Infrastructure;
using Suatra.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddVersioningServices();
builder.Services.AddSwaggerServices();


var app = builder.Build();

app.UseSeedData();
app.UseCustomMiddlewareHandler();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerDocumentation();
app.MapControllers();


app.Run();
