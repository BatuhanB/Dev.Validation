using Dev.Validation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Dev.Validation.Api.Filters;
public class ValidationFilter : IAsyncActionFilter
{
    private readonly ILogger<ValidationFilter> _logger;

    public ValidationFilter(ILogger<ValidationFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errs = context.ModelState.Where(x => x.Value.Errors.Any())
                .ToDictionary(e => e.Key, e => e.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

            var errorViewModel = new List<ErrorViewModel>();
            foreach (var error in errs)
            {
                errorViewModel.Add(new ErrorViewModel(error.Key, error.Value.ToList()));
                foreach (var log in error.Value.ToList())
                {
                    _logger.LogWarning($"{error.Key} --> {log}");
                }
            }
            
            context.Result = new BadRequestObjectResult(errorViewModel);
            return;
        }
        await next();
    }
}