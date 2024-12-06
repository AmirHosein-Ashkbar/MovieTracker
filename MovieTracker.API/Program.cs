using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MovieTracker.API.Extensions;
using MovieTracker.API.HealthChecks;
using MovieTracker.Application;
using MovieTracker.Infrastructure;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context,configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));




builder.Services.AddControllers();
builder.Services.AddSwagger();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddHealthChecks()
    .AddCheck<TMDBHealthCheck>("TMDB")
    .AddCheck<SampleHealthCheck>("sample");

//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails( 
    options => options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
    });


var app = builder.Build();

app.UseSerilogRequestLogging();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
