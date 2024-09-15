using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Domain.Entities;

public class User : BaseEntity<User>
{
    public string? Name { get; private set; }
    public string? MobilePhone { get; private set; }
    public string? Email { get; private set; }
    public EnumTypeUser? Type { get; private set; }
    public string? Password { get; private set; }

    public virtual List<Scheduled>? ListScheduled { get; private set; }

    public User() { }

    public User(string name, string mobilePhone, string email, EnumTypeUser type, string password, List<Scheduled>? listScheduled)
    {
        Name = name;
        MobilePhone = mobilePhone;
        Email = email;
        Type = type;
        Password = password;
        ListScheduled = listScheduled;
    }
}