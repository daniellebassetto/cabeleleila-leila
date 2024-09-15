using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputIdentifierScheduled
{
    public DateTime? DateTime { get; set; }

    public InputIdentifierScheduled() { }

    [JsonConstructor]
    public InputIdentifierScheduled(DateTime dateTime)
    {
        DateTime = dateTime;
    }
}