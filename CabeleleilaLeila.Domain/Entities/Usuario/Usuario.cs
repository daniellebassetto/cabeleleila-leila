using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Domain.Entities;

public class Usuario : BaseEntity<Usuario>
{
    public string? Nome { get; private set; }
    public string? Cpf { get; private set; }
    public string? Celular { get; private set; }
    public string? Email { get; private set; }
    public EnumTipoUsuario? Tipo { get; private set; }

    public Usuario() { }

    public Usuario(string nome, string cpf, string celular, string email, EnumTipoUsuario tipo)
    {
        Nome = nome;
        Cpf = cpf;
        Celular = celular;
        Email = email;
        Tipo = tipo;
    }
}