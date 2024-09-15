using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputLoginUser
{
    public string? Email { get; set; }
    public string? Password { get; set; }

    public InputLoginUser() { }

    [JsonConstructor]
    public InputLoginUser(string email, string password)
    {
        Email = email;
        Password = password;
    }
}