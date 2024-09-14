namespace CabeleleilaLeila.Arguments;

public class OutputUsuario
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ChangeDate { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Celular { get; set; }
    public string? Email { get; set; }
    public EnumTipoUsuario? Tipo { get; set; }
}