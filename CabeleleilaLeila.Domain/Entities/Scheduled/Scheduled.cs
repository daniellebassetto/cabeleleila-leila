using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Domain.Entities;

public class Scheduled : BaseEntity<Scheduled>
{
    public long UserId { get; private set; }
    public DateTime DateTime { get; private set; }
    public EnumServiceScheduled Service { get; private set; }
    public EnumStatusScheduled Status { get; private set; }
    public string? Observation { get; private set; }

    public virtual User? User { get; private set; }

    public Scheduled() { }

    public Scheduled(long userId, DateTime datetime, EnumServiceScheduled service, EnumStatusScheduled status, string? observation, User? user)
    {
        UserId = userId;
        DateTime = datetime;
        Service = service;
        Status = status;
        Observation = observation;
        User = user;
    }
}