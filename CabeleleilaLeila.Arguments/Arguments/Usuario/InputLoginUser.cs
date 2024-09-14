using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputLoginUser
{
    public string? Email { get; private set; }
    public string? Senha { get; private set; }

    public InputLoginUser() { }

    [JsonConstructor]
    public InputLoginUser(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }
}