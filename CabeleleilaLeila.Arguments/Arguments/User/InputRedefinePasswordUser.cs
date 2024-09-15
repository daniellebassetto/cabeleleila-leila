using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputRedefinePasswordUser
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres.")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(12, ErrorMessage = "A senha deve ter no máximo 12 caracteres.")]
    public string? OldPassword { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(12, ErrorMessage = "A senha deve ter no máximo 12 caracteres.")]
    public string? NewPassword { get; set; }

    public InputRedefinePasswordUser() { }

    [JsonConstructor]
    public InputRedefinePasswordUser(string email, string oldPassword, string newPassword)
    {
        Email = email;
        OldPassword = oldPassword;
        NewPassword = newPassword;
    }
}