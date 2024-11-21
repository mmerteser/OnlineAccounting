using FluentValidation;
using OnlineAccounting.Domain.Results;

namespace OnlineAccounting.WebApi.Middlewares;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            context.Response.ContentType = "application/json";
            string messageString = e.InnerException is not null
                ? e.Message + Environment.NewLine + e.InnerException?.Message
                : e.Message;

            logger.LogError($"PATH: {context.Request.Path} - {messageString}");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            
            // if(e.GetType() == typeof(UnauthorizedAccessException))
            if (e.GetType() == typeof(ValidationException))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync(e.Message);
            }
            var errorResult = new ErrorResult(messageString);
            await context.Response.WriteAsync(errorResult.ToString());
        }
    }
}