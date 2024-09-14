using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputCreateUsuario
{
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
    public string? Nome { get; private set; }

    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres numéricos.")]
    public string? Cpf { get; private set; }

    [StringLength(13, MinimumLength = 13, ErrorMessage = "O número de celular deve ter exatamente 13 caracteres numéricos.")]
    public string? Celular { get; private set; }

    [MaxLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres.")]
    public string? Email { get; private set; }
    
    public EnumTipoUsuario? Tipo { get; private set; }

    public InputCreateUsuario() { }

    [JsonConstructor]
    public InputCreateUsuario(string nome, string cpf, string celular, string email, EnumTipoUsuario tipo)
    {
        Nome = nome;
        Cpf = cpf;
        Celular = celular;
        Email = email;
        Tipo = tipo;
    }
}