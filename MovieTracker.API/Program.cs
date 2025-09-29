using MovieTracker.API.Extensions;
using MovieTracker.API.Filters;
using MovieTracker.Application;
using MovieTracker.Infrastructure;
using Serilog;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context,configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddMiddlewares();

builder.Services.AddControllers(configuration =>
{
    configuration.Filters.Add<ValidationExceptionHandlingFilter>();
});


builder.Services.AddSwagger();
//builder.Services.AddOpenApi();


builder.Services.AddHealthCheck();  

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddProblemDetails(
    options => options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
        context.ProblemDetails.Extensions["method"] = context.HttpContext.Request.Method;
        context.ProblemDetails.Extensions["route"] = context.HttpContext.Request.Path.Value;
    });


var app = builder.Build();

app.MapHealthChecks();

app.MapControllers();


app.UseSwaggerMiddleware();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();


app.Run();
