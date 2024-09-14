using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputUpdateAgendamento
{
    public DateTime? DataHora { get; private set; }
    public EnumServicoAgendamento Servico { get; private set; }
    public EnumStatusAgendamento Status { get; private set; }

    [MaxLength(1000, ErrorMessage = "A observação deve ter no máximo 1000 caracteres.")]
    public string? Observacao { get; private set; }

    public InputUpdateAgendamento() { }

    [JsonConstructor]
    public InputUpdateAgendamento(DateTime dataHora, EnumServicoAgendamento servico, EnumStatusAgendamento status, string? observacao)
    {
        DataHora = dataHora;
        Servico = servico;
        Status = status;
        Observacao = observacao;
    }
}