using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputIdentifierUser
{
    public string? Email { get; set; }

    public InputIdentifierUser() { }

    [JsonConstructor]
    public InputIdentifierUser(string email)
    {
        Email = email;
    }
}