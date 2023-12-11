using Dev.Validation.Models.Entities;
using FluentValidation;

namespace Dev.Validation.Validator;
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
                        .WithMessage("Name cannot be empty!")
                        .MinimumLength(3)
                        .WithMessage("Name cannot be lower than 3 characters!")
                        .Must(CheckWhiteSpaceProductName)
                        .WithMessage("Name can not include spaces!");

        RuleFor(x => x.Price).NotEmpty()
                        .WithMessage("Name cannot be empty!")
                        .GreaterThan(0)
                        .WithMessage("Price must be greater than 0!");

        RuleFor(x => x.Stock).NotEmpty()
                        .WithMessage("Stock cannot be empty!")
                        .GreaterThanOrEqualTo(0)
                        .WithMessage("Stock must be greater than 0!");
    }

    private bool CheckWhiteSpaceProductName(string name) => !string.IsNullOrWhiteSpace(name);
    
}
