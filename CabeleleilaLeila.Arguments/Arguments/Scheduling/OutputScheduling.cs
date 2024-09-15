namespace CabeleleilaLeila.Arguments;

public class OutputScheduling
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
    public long? UserId { get; set; }
    public DateTime? DateTime { get; set; }
    public EnumServiceScheduling Service { get; set; }
    public EnumStatusScheduling Status { get; set; }
    public string? Observation { get; set; }

    public OutputUser? User { get; set; }
}