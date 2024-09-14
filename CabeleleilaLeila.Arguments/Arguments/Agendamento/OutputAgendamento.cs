namespace CabeleleilaLeila.Arguments;

public class OutputAgendamento
{
    public long Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public int Number {  get; set; }
    public long? UsuarioId { get; set; }
    public DateTime? DataHora { get; set; }
    public EnumServicoAgendamento Servico { get; set; }
    public EnumStatusAgendamento Status { get; set; }
    public string? Observacao { get; set; }

    public OutputUsuario? Usuario { get; private set; }
}