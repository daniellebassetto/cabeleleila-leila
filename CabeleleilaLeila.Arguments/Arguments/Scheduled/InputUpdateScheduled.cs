using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputUpdateScheduled
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime? DateTime { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public EnumServiceScheduled Service { get; set; }

    [MaxLength(1000, ErrorMessage = "A observação deve ter no máximo 1000 caracteres.")]
    public string? Observation { get; set; }

    public InputUpdateScheduled() { }

    [JsonConstructor]
    public InputUpdateScheduled(DateTime datetime, EnumServiceScheduled service, string? observation)
    {
        DateTime = datetime;
        Service = service;
        Observation = observation;
    }
}