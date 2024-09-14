using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputCreateAgendamento
{
    public long? UsuarioId { get; private set; }
    public DateTime? DataHora { get; private set; }
    public EnumServicoAgendamento Servico { get; private set; }
    public EnumStatusAgendamento Status { get; private set; }

    [MaxLength(1000, ErrorMessage = "A observação deve ter no máximo 1000 caracteres.")]
    public string? Observacao { get; private set; }

    public InputCreateAgendamento() { }

    [JsonConstructor]
    public InputCreateAgendamento(long usuarioId, DateTime dataHora, EnumServicoAgendamento servico, EnumStatusAgendamento status, string? observacao)
    {
        UsuarioId = usuarioId;
        DataHora = dataHora;
        Servico = servico;
        Status = status;
        Observacao = observacao;
    }
}