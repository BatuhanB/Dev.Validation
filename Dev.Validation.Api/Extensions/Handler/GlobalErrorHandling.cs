using Dev.Validation.Models.Entities;
using Dev.Validation.Validator;
using FluentValidation;
using System.Net;

namespace Dev.Validation.Api.Extensions.Handler;
public class GlobalErrorHandling(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {

           await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        switch (exception)
        {
            case ValidationException validationException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new { StatusCode = context.Response.StatusCode, Errors = validationException.Errors });
                break;

            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(new { StatusCode = context.Response.StatusCode, Message = "Internal Server Error." });
                break;
        }
    }
}
