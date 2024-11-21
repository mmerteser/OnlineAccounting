using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineAccounting.WebApi.ActionFilters;

public sealed class ValidationActionFilter(IServiceProvider _serviceProvider) : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
            var validator = _serviceProvider.GetService(validatorType) as IValidator;
            if (validator != null)
            {
                var validationContext = new ValidationContext<object>(argument);
                var validationResult = validator.Validate(validationContext);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(x => x.ErrorMessage).ToArray()
                        );

                    context.Result = new BadRequestObjectResult(new ValidationProblemDetails(errors)
                    {
                        Title = "Validation Failed",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "One or more validation errors occurred.",
                        Instance = context.HttpContext.Request.Path
                    });

                    return;
                }
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}