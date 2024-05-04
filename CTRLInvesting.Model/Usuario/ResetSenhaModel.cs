using System.ComponentModel.DataAnnotations;

namespace CTRLInvesting.Model.Usuario;

public class ResetSenhaModel
{
    [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
    [Required(ErrorMessage = "Necessário preencher o campo")]
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

}
