using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputLoginUser
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }

    public InputLoginUser() { }

    [JsonConstructor]
    public InputLoginUser(string email, string password)
    {
        Email = email;
        Password = password;
    }
}