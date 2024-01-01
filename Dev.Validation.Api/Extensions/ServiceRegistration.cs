using Dev.Validation.Api.Filters;
using Dev.Validation.BusinessLogics.Interfaces;
using Dev.Validation.BusinessLogics.Services;
using Dev.Validation.Validator;
using FluentValidation.AspNetCore;

namespace Dev.Validation.Extensions;
public static class ServiceRegistration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddKeyedSingleton<IProductService, ProductService>("productService");
        
        services.AddControllers(opt => opt.Filters.Add<ValidationFilter>())
    .AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<ProductValidator>())
    .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);
    }
}
