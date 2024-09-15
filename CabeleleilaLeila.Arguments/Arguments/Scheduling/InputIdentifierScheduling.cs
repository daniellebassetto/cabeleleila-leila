using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputIdentifierScheduling
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime? DateTime { get; set; }

    public InputIdentifierScheduling() { }

    [JsonConstructor]
    public InputIdentifierScheduling(DateTime dateTime)
    {
        DateTime = dateTime;
    }
}