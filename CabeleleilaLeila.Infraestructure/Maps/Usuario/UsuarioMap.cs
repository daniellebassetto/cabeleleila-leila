using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Infraestructure.Maps;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        //builder.HasMany(x => x.ListOrder).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Id).HasColumnType("BIGINT");
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro");
        builder.Property(x => x.DataCadastro).IsRequired();
        builder.Property(x => x.DataCadastro).HasColumnType("DATETIME");
        builder.Property(x => x.DataCadastro).ValueGeneratedNever();

        builder.Property(x => x.DataAlteracao).HasColumnName("data_alteracao");
        builder.Property(x => x.DataAlteracao).HasColumnType("DATETIME");
        builder.Property(x => x.DataAlteracao).ValueGeneratedNever();

        builder.Property(x => x.Nome).HasColumnName("nome");
        builder.Property(x => x.Nome).IsRequired();
        builder.Property(x => x.Nome).HasColumnType("VARCHAR(80)");
        builder.Property(x => x.Nome).ValueGeneratedNever();

        builder.Property(x => x.Cpf).HasColumnName("cpf");
        builder.Property(x => x.Cpf).IsRequired();
        builder.Property(x => x.Cpf).HasColumnType("VARCHAR(11)");
        builder.Property(x => x.Cpf).ValueGeneratedNever();

        builder.Property(x => x.Celular).HasColumnName("celular");
        builder.Property(x => x.Celular).IsRequired();
        builder.Property(x => x.Celular).HasColumnType("VARCHAR(13)");
        builder.Property(x => x.Celular).ValueGeneratedNever();

        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.Email).HasColumnType("VARCHAR(256)");
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Email).ValueGeneratedNever();

        builder.Property(x => x.Tipo).HasColumnName("tipo");
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Tipo).HasColumnType("INT");
        builder.Property(x => x.Tipo).ValueGeneratedNever();

        builder.Property(x => x.Senha).HasColumnName("senha");
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Senha).HasColumnType("VARCHAR(100)");
        builder.Property(x => x.Senha).ValueGeneratedNever();
    }
}