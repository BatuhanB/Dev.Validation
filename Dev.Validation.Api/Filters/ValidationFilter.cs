using Dev.Validation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dev.Validation.Api.Filters;
public class ValidationFilter : IAsyncActionFilter
{
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
            }
            context.Result = new BadRequestObjectResult(errorViewModel);
            return;
        }
        await next();
    }
}