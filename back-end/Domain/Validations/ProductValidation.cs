using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation()
    {
        RuleFor(produto => produto.Name)
            .NotEmpty()
                .WithMessage("O campo Nome precisa ser fornecido")
            .Length(2, 200)
                .WithMessage("O campo Nome precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(produto => produto.Description)
            .NotEmpty()
                .WithMessage("O campo Descrição precisa ser fornecido")
            .Length(2, 1000)
                .WithMessage("O campo Descrição precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(produto => produto.Price)
            .NotEmpty()
                .WithMessage("O campo Preço precisa ser fornecido")
            .GreaterThan(0)
                .WithMessage("O campo Preço precisa ser maior que {ComparisonValue}");
    }
}