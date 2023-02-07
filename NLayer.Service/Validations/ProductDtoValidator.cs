using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertName} is required");

            RuleFor(p => p.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{{PropertName} CategoryId must be at least 1 !");
            RuleFor(p => p.Price).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertName} Price must be at least 0 !");
            RuleFor(p => p.Stock).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertName} stock must be at least 0 !");

        }
    }
}


// -- GreaterThanOrEqualTo()
//RuleFor(p => p.CategoryId).GreaterThanOrEqualTo(1).WithMessage("{{PropertName} CategoryId must be at least 1 !");
//RuleFor(p => p.Price).GreaterThanOrEqualTo(0).WithMessage("{PropertName} Price must be at least 0 !");
//RuleFor(p => p.Stock).GreaterThanOrEqualTo(0).WithMessage("{PropertName} stock must be at least 0 !");