using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Arguments;

public class InputCreateUsuario
{
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
    public string? Nome { get; private set; }

    [StringLength(13, MinimumLength = 13, ErrorMessage = "O número de celular deve ter exatamente 13 caracteres numéricos.")]
    public string? Celular { get; private set; }

    [MaxLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres.")]
    public string? Email { get; private set; }
    
    public EnumTipoUsuario? Tipo { get; private set; }

    [MaxLength(12, ErrorMessage = "A senha deve ter no máximo 12 caracteres.")]
    public string? Senha { get; private set; }

    public InputCreateUsuario() { }

    [JsonConstructor]
    public InputCreateUsuario(string nome, string celular, string email, EnumTipoUsuario tipo, string senha)
    {
        Nome = nome;
        Celular = celular;
        Email = email;
        Tipo = tipo;
        Senha = senha;
    }
}