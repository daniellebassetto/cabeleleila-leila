using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputCreateScheduled
{
    public long? UserId { get; set; }
    public DateTime? DateTime { get; set; }
    public EnumServiceScheduled Service { get; set; }

    [MaxLength(1000, ErrorMessage = "A observação deve ter no máximo 1000 caracteres.")]
    public string? Observation { get; set; }

    public InputCreateScheduled() { }

    [JsonConstructor]
    public InputCreateScheduled(long userId, DateTime datetime, EnumServiceScheduled service, string? observation)
    {
        UserId = userId;
        DateTime = datetime;
        Service = service;
        Observation = observation;
    }
}