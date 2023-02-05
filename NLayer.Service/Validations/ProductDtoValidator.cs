using FluentValidation;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertName} is required");

            RuleFor(p => p.CategoryId).InclusiveBetween(1 , int.MaxValue).WithMessage("{{PropertName} CategoryId must be at least 1 !");
            RuleFor(p => p.Price).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertName} Price must be at least 0 !");
            RuleFor(p => p.Stock).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertName} stock must be at least 0 !");

        }
    }
}


// -- GreaterThanOrEqualTo()
//RuleFor(p => p.CategoryId).GreaterThanOrEqualTo(1).WithMessage("{{PropertName} CategoryId must be at least 1 !");
//RuleFor(p => p.Price).GreaterThanOrEqualTo(0).WithMessage("{PropertName} Price must be at least 0 !");
//RuleFor(p => p.Stock).GreaterThanOrEqualTo(0).WithMessage("{PropertName} stock must be at least 0 !");


public class MyClassValidator : AbstractValidator<ProductDto>
{
    public MyClassValidator()
    {
        RuleFor(x => x.Password)
            .MinimumLength(8)
            .WithMessage("Şifre en az 8 karakter uzunluğunda olmalıdır.")
            .Must(x =>
                x.Any(c => char.IsUpper(c)) &&
                x.Any(c => char.IsLower(c)) &&
                x.Any(c => char.IsDigit(c)))
            .WithMessage("Şifre en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
    }
}
