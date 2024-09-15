using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputIdentifierScheduled
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime? DateTime { get; set; }

    public InputIdentifierScheduled() { }

    [JsonConstructor]
    public InputIdentifierScheduled(DateTime dateTime)
    {
        DateTime = dateTime;
    }
}