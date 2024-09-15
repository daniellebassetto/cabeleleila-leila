namespace CabeleleilaLeila.Arguments;

public class OutputScheduled
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
    public long? UserId { get; set; }
    public DateTime? DateTime { get; set; }
    public EnumServiceScheduled Service { get; set; }
    public EnumStatusScheduled Status { get; set; }
    public string? Observation { get; set; }

    public OutputUser? User { get; private set; }
}