using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputIdentifierUsuario
{
    public string? Email { get; private set; }

    public InputIdentifierUsuario() { }

    [JsonConstructor]
    public InputIdentifierUsuario(string email)
    {
        Email = email;
    }
}