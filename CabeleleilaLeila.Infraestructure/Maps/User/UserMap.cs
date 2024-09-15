using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Infraestructure.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuario");

        builder.HasMany(x => x.ListScheduled).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Id).HasColumnType("BIGINT");
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.CreationDate).HasColumnName("data_cadastro");
        builder.Property(x => x.CreationDate).IsRequired();
        builder.Property(x => x.CreationDate).HasColumnType("DATETIME");
        builder.Property(x => x.CreationDate).ValueGeneratedNever();

        builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");
        builder.Property(x => x.ChangeDate).HasColumnType("DATETIME");
        builder.Property(x => x.ChangeDate).ValueGeneratedNever();

        builder.Property(x => x.Name).HasColumnName("nome");
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Name).HasColumnType("VARCHAR(80)");
        builder.Property(x => x.Name).ValueGeneratedNever();

        builder.Property(x => x.MobilePhone).HasColumnName("celular");
        builder.Property(x => x.MobilePhone).IsRequired();
        builder.Property(x => x.MobilePhone).HasColumnType("VARCHAR(13)");
        builder.Property(x => x.MobilePhone).ValueGeneratedNever();

        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.Email).HasColumnType("VARCHAR(256)");
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Email).ValueGeneratedNever();

        builder.Property(x => x.Type).HasColumnName("tipo");
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Type).HasColumnType("INT");
        builder.Property(x => x.Type).ValueGeneratedNever();

        builder.Property(x => x.Password).HasColumnName("senha");
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Password).HasColumnType("VARCHAR(100)");
        builder.Property(x => x.Password).ValueGeneratedNever();
    }
}