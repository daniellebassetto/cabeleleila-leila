using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Infraestructure.Maps;
using Microsoft.EntityFrameworkCore;

namespace CabeleleilaLeila.Infraestructure;

public class CabeleleilaLeilaContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Scheduled> Scheduled { get; set; }

    public CabeleleilaLeilaContext() { }

    public CabeleleilaLeilaContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());

        base.OnModelCreating(modelBuilder);
    }
}