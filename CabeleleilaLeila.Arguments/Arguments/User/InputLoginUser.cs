using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputLoginUser
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres.")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(12, ErrorMessage = "A senha deve ter no máximo 12 caracteres.")]
    public string? Password { get; set; }

    public InputLoginUser() { }

    [JsonConstructor]
    public InputLoginUser(string email, string password)
    {
        Email = email;
        Password = password;
    }
}