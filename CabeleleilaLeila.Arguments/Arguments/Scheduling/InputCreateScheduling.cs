using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputCreateScheduling
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public long? UserId { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime? DateTime { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public EnumServiceScheduling Service { get; set; }

    [MaxLength(1000, ErrorMessage = "A observação deve ter no máximo 1000 caracteres.")]
    public string? Observation { get; set; }

    public InputCreateScheduling() { }

    [JsonConstructor]
    public InputCreateScheduling(long userId, DateTime datetime, EnumServiceScheduling service, string? observation)
    {
        UserId = userId;
        DateTime = datetime;
        Service = service;
        Observation = observation;
    }
}