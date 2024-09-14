using Newtonsoft.Json;

namespace CabeleleilaLeila.Arguments;

public class InputIdentifierAgendamento
{
    public int? Number { get; private set; }

    public InputIdentifierAgendamento() { }

    [JsonConstructor]
    public InputIdentifierAgendamento(int number)
    {
        Number = number;
    }
}