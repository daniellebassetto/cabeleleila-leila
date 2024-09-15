using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputIdentifierUser
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres.")]
    public string? Email { get; set; }

    public InputIdentifierUser() { }

    [JsonConstructor]
    public InputIdentifierUser(string email)
    {
        Email = email;
    }
}