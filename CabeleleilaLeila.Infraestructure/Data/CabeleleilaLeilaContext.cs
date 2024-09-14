using Microsoft.EntityFrameworkCore;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Infraestructure.Maps;

namespace CabeleleilaLeila.Infraestructure;

public class CabeleleilaLeilaContext : DbContext
{
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Agendamento> Agendamento { get; set; }

    public CabeleleilaLeilaContext() { }

    public CabeleleilaLeilaContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());

        base.OnModelCreating(modelBuilder);
    }
}