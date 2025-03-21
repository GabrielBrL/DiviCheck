using System.Text.RegularExpressions;
using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Model.Usuario;
using FluentValidation;

namespace CTRLInvesting.Client.Validations;

public class FluentValidationResetSenha : AbstractValidator<ResetSenhaModel>
{
    private readonly IUsuarioService _userService;
    public FluentValidationResetSenha(IUsuarioService userService)
    {
        _userService = userService;
        RuleFor(x => x.Email)
        .Cascade(CascadeMode.Stop)
        .NotEmpty().WithMessage("Necessário preencher o campo.")
        .EmailAddress()
        .MustAsync(async (value, cancellationToken) => await UniqueEmail(value))
        .When(_ => !string.IsNullOrEmpty(_.Email) && Regex.IsMatch(_.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase), ApplyConditionTo.CurrentValidator)
        .WithMessage("O email informado não existe.");
    }
    private async Task<bool> UniqueEmail(string email)
    {
        return !(await _userService.GetUniqueUserByEmailAsync(email));
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
