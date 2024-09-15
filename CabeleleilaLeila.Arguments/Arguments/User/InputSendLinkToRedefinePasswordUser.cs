using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputSendLinkToRedefinePasswordUser
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres.")]
    public string? Email { get; set; }

    public InputSendLinkToRedefinePasswordUser() { }

    [JsonConstructor]
    public InputSendLinkToRedefinePasswordUser(string email)
    {
        Email = email;
    }
}