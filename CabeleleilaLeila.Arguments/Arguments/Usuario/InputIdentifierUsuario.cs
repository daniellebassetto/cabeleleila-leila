using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputIdentifierUsuario
{
    public string? Cpf { get; private set; }

    public InputIdentifierUsuario() { }

    [JsonConstructor]
    public InputIdentifierUsuario(string cpf)
    {
        Cpf = cpf;
    }
}