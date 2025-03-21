using CTRLInvesting.Model.Usuario;
using FluentValidation;

namespace CTRLInvesting.Client.Validations;

public class FluentValidationConfirmResetSenha : AbstractValidator<ResetSenhaModel>
{
    public FluentValidationConfirmResetSenha()
    {
        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Necessário preencher o campo.")
        .MinimumLength(8).WithMessage("Deve conter no minimo 8 caracteres.")
        .MaximumLength(20).WithMessage("Deve conter no máximo 20 caracteres.");
        
        RuleFor(x => x.ConfirmPassword)
        .NotEmpty().WithMessage("Necessário preencher o campo.")
        .Length(8, 20).WithMessage("Deve conter no minimo 8 caracteres.")
        .Equal(x => x.Password).WithMessage("As senhas não coincidem.");

    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result =
        await ValidateAsync(ValidationContext<ResetSenhaModel>.CreateWithOptions((ResetSenhaModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
