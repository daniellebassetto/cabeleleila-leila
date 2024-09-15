using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputSendLinkToRedefinePasswordUser
{
    public string? Email { get; set; }

    public InputSendLinkToRedefinePasswordUser() { }

    [JsonConstructor]
    public InputSendLinkToRedefinePasswordUser(string email)
    {
        Email = email;
    }
}