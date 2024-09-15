using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Domain.Entities;

public class Scheduling : BaseEntity<Scheduling>
{
    public long UserId { get; private set; }
    public DateTime DateTime { get; private set; }
    public EnumServiceScheduling Service { get; private set; }
    public EnumStatusScheduling Status { get; private set; }
    public string? Observation { get; private set; }

    public virtual User? User { get; private set; }

    public Scheduling() { }

    public Scheduling(long userId, DateTime datetime, EnumServiceScheduling service, EnumStatusScheduling status, string? observation, User? user)
    {
        UserId = userId;
        DateTime = datetime;
        Service = service;
        Status = status;
        Observation = observation;
        User = user;
    }
}