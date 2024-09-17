using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Infraestructure.Maps;
using Microsoft.EntityFrameworkCore;

namespace CabeleleilaLeila.Infraestructure;

public class CabeleleilaLeilaContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Scheduling> Scheduling { get; set; }

    public CabeleleilaLeilaContext() { }

    public CabeleleilaLeilaContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new SchedulingMap());

        modelBuilder.Entity<User>().HasData(new User("Leila", "5514991234567", "cabeleleiladesin@outlook.com", Arguments.EnumTypeUser.Admin, "1234", null)
        {
            Id = 1,
            CreationDate = DateTime.Now,
            ChangeDate = null
        });

        base.OnModelCreating(modelBuilder);
    }
}