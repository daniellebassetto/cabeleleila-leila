namespace CabeleleilaLeila.Arguments;

public class OutputUser
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
    public string? Name { get; set; }
    public string? MobilePhone { get; set; }
    public string? Email { get; set; }
    public EnumTypeUser? Type { get; set; }

    public List<OutputScheduling>? ListScheduling { get; set; }
}