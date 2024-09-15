using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputCreateUser
{
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
    public string? Name { get; set; }

    [StringLength(13, MinimumLength = 13, ErrorMessage = "O número de celular deve ter exatamente 13 caracteres numéricos.")]
    public string? MobilePhone { get; set; }

    [MaxLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres.")]
    public string? Email { get; set; }

    [MaxLength(12, ErrorMessage = "A senha deve ter no máximo 12 caracteres.")]
    public string? Password { get; set; }

    [MaxLength(12, ErrorMessage = "A senha deve ter no máximo 12 caracteres.")]
    public string? ConfirmPassword { get; set; }

    public InputCreateUser() { }

    [JsonConstructor]
    public InputCreateUser(string name, string mobilePhone, string email, string password, string confirmPassword)
    {
        Name = name;
        MobilePhone = mobilePhone;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
}