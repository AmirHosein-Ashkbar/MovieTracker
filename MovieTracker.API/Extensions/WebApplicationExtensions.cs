using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace MovieTracker.API.Extensions;

public static class WebApplicationExtensions
{
    public static IEndpointRouteBuilder MapHealthChecks(this IEndpointRouteBuilder app)
    {
        app.MapHealthChecks("/healthz", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        return app;
    }


    public static WebApplication UseSwaggerMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        return app;
    }
}
