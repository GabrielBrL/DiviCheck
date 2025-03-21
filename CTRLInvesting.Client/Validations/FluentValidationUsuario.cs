using System.Text.RegularExpressions;
using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Model.Usuario;
using FluentValidation;

namespace CTRLInvesting.Client.Validations;

public class FluentValidationRegisterUsuario : AbstractValidator<RegisterModel>
{
    private readonly IUsuarioService _userService;
    public FluentValidationRegisterUsuario(IUsuarioService userService)
    {
        _userService = userService;
        
        RuleFor(x => x.Usuario)
        .Cascade(CascadeMode.Stop)
        .NotEmpty().WithMessage("Necessário preencher o campo.")
        .MaximumLength(100).WithMessage("No máximo 100 caracteres.")
        .MustAsync(async (value, cancellationToken) => await UniqueUsuario(value))
        .WithMessage("O usuário informado já foi cadastrado.");;

        RuleFor(x => x.Email)
        .Cascade(CascadeMode.Stop)
        .NotEmpty().WithMessage("Necessário preencher o campo.")
        .EmailAddress()
        .MustAsync(async (value, cancellationToken) => await UniqueEmail(value))
        .When(_ => !string.IsNullOrEmpty(_.Email) && Regex.IsMatch(_.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase), ApplyConditionTo.CurrentValidator )
        .WithMessage("O email informado já foi cadastrado.");

        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Necessário preencher o campo.")
        .MinimumLength(8).WithMessage("Deve conter no minimo 8 caracteres.")
        .MaximumLength(20).WithMessage("Deve conter no máximo 20 caracteres.");

        RuleFor(x => x.ConfirmPassword)
        .NotEmpty().WithMessage("Necessário preencher o campo.")
        .Length(8, 20).WithMessage("Deve conter no minimo 8 caracteres.")
        .Equal(x => x.Password).WithMessage("As senhas não coincidem.");        
    }
    private async Task<bool> UniqueEmail(string email)
    {
        return await _userService.GetUniqueUserByEmailAsync(email);
    }
    private async Task<bool> UniqueUsuario(string usuario)
    {
        return await _userService.GetUserByUsuarioAsync(usuario);
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result =
            await ValidateAsync(ValidationContext<RegisterModel>.CreateWithOptions((RegisterModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
}
