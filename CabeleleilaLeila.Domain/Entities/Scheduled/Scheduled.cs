using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Domain.Entities;

public class Scheduled : BaseEntity<Scheduled>
{
    public long UserId { get; set; }
    public DateTime DateTime { get; set; }
    public EnumServiceScheduled Service { get; set; }
    public EnumStatusScheduled Status { get; set; }
    public string? Observation { get; set; }

    public User? User { get; private set; }

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