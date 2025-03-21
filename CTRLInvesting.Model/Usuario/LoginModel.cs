using System.ComponentModel.DataAnnotations;

namespace CTRLInvesting.Model.Usuario;

public class LoginModel
{
    [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
    [Required(ErrorMessage = "Necessário preencher o campo")]
    public string Usuario { get; set; }
    [MaxLength(20, ErrorMessage = "No máximo 20 caracteres")]
    [Required(ErrorMessage = "Necessário preencher o campo")]
    public string Password { get; set; }
}
