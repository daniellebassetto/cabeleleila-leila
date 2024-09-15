using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputUpdateScheduled
{
    public DateTime? DateTime { get; set; }
    public EnumServiceScheduled Service { get; set; }
    public EnumStatusScheduled Status { get; set; }

    [MaxLength(1000, ErrorMessage = "A observação deve ter no máximo 1000 caracteres.")]
    public string? Observation { get; set; }

    public InputUpdateScheduled() { }

    [JsonConstructor]
    public InputUpdateScheduled(DateTime datetime, EnumServiceScheduled service, EnumStatusScheduled status, string? observation)
    {
        DateTime = datetime;
        Service = service;
        Status = status;
        Observation = observation;
    }
}