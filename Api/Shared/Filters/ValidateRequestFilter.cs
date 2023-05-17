using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Shared.Filters;

public class ValidateRequestFilter : ActionFilterAttribute
{
    private readonly IServiceProvider _serviceProvider;

    public ValidateRequestFilter(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var arguments = context.ActionArguments;
        foreach (var argument in arguments)
        {
            var modelType = argument.Value!.GetType();
            var validatorType = typeof(IValidator<>).MakeGenericType(modelType);
            var validator = _serviceProvider.GetService(validatorType);
            if (validator != null)
            {
                var validateMethod = validator.GetType().GetMethod("Validate");
                var result = (ValidationResult)validateMethod!.Invoke(validator, new[] { argument.Value })!;
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                    {
                        context.ModelState.AddModelError("", error.ErrorMessage);
                    }
                }
            }
        }

        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }

        base.OnActionExecuting(context);
    }
}
