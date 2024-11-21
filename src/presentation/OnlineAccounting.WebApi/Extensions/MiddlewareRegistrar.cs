using OnlineAccounting.WebApi.Middlewares;

namespace OnlineAccounting.WebApi.Extensions;

public static class MiddlewareRegistrar
{
    public static void AddMiddlewares(this IServiceCollection services)
    {
        services.AddScoped<GlobalExceptionHandler>();
    }
    public static void UseMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();
    }
}