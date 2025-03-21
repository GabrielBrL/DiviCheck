using CTRLInvesting.Model.CalculadoraRendaFixa;
using FluentValidation;

namespace CTRLInvesting.Client.Validations;

public class FluentValidationCalculadoraSelic : AbstractValidator<CalculadoraSelic>
{
    public FluentValidationCalculadoraSelic()
    {
        RuleFor(x => x.Prazo).NotNull().WithMessage("Necessário informar o número de meses ou anos.")
                             .GreaterThan(0).WithMessage("Prazo deve ser maior que 0.");
        RuleFor(x => x.valorInicial).NotNull().WithMessage("Necessário informar o valor inicial investido.")
                                    .GreaterThan(0).WithMessage("Valor inicial deve ser maior que 0.");
        RuleFor(x => x.valorMensal).GreaterThanOrEqualTo(0).WithMessage("Valor inicial deve ser maior que 0.");
        RuleFor(x => x.PercentualRentabilidade).GreaterThan(0).WithMessage("Percentual deve ser maior que 0.");
    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result =
            await ValidateAsync(ValidationContext<CalculadoraSelic>.CreateWithOptions((CalculadoraSelic)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };

}
