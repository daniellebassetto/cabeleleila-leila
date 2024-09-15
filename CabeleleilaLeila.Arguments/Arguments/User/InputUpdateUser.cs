using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputUpdateUser
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "O número de celular deve ter exatamente 13 caracteres numéricos.")]
    public string? MobilePhone { get; set; }

    public InputUpdateUser() { }

    [JsonConstructor]
    public InputUpdateUser(string name, string mobilePhone)
    {
        Name = name;
        MobilePhone = mobilePhone;
    }
}