using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Infraestructure.Maps;

public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
{
    public void Configure(EntityTypeBuilder<Agendamento> builder)
    {
        builder.ToTable("agendamento");

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

        builder.Property(x => x.Number).HasColumnName("numero");
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.Number).HasColumnType("INT");
        builder.Property(x => x.Number).ValueGeneratedNever();

        builder.Property(x => x.UsuarioId).HasColumnName("id_usuario");
        builder.Property(x => x.UsuarioId).IsRequired();
        builder.Property(x => x.UsuarioId).HasColumnType("BIGINT");
        builder.Property(x => x.UsuarioId).ValueGeneratedNever();

        builder.Property(x => x.DataHora).HasColumnName("data_hora");
        builder.Property(x => x.DataHora).IsRequired();
        builder.Property(x => x.DataHora).HasColumnType("DATETIME");
        builder.Property(x => x.DataHora).ValueGeneratedNever();

        builder.Property(x => x.Servico).HasColumnName("servico");
        builder.Property(x => x.Servico).IsRequired();
        builder.Property(x => x.Servico).HasColumnType("INT");
        builder.Property(x => x.Servico).ValueGeneratedNever();

        builder.Property(x => x.Status).HasColumnName("status");
        builder.Property(x => x.Status).HasColumnType("INT");
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Status).ValueGeneratedNever();

        builder.Property(x => x.Observacao).HasColumnName("observacao");
        builder.Property(x => x.Observacao).HasColumnType("VARCHAR(1000)");
        builder.Property(x => x.Observacao).ValueGeneratedNever();
    }
}