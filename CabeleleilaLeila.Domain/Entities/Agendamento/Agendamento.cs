using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Domain.Entities;

public class Agendamento : BaseEntity<Agendamento>
{
    public int Number {  get; set; }
    public long UsuarioId { get; set; }
    public DateTime DataHora { get; set; }
    public EnumServicoAgendamento Servico { get; set; }
    public EnumStatusAgendamento Status { get; set; }
    public string? Observacao { get; set; }

    public OutputUsuario? Usuario { get; private set; }

    public Agendamento() { }

    public Agendamento(int number, long usuarioId, DateTime dataHora, EnumServicoAgendamento servico, EnumStatusAgendamento status, string? observacao, OutputUsuario? usuario)
    {
        Number = number;
        UsuarioId = usuarioId;
        DataHora = dataHora;
        Servico = servico;
        Status = status;
        Observacao = observacao;
        Usuario = usuario;
    }
}