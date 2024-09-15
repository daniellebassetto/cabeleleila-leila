using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputRedefinePasswordUser
{
    public string? Email { get; set; }
    public string? OldPassword { get; set; }
    public string? NewPassword { get; set; }

    public InputRedefinePasswordUser() { }

    [JsonConstructor]
    public InputRedefinePasswordUser(string email, string oldPassword, string newPassword)
    {
        Email = email;
        OldPassword = oldPassword;
        NewPassword = newPassword;
    }
}