using CabeleleilaLeila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CabeleleilaLeila.Infraestructure.Maps;

public class ScheduledMap : IEntityTypeConfiguration<Scheduled>
{
    public void Configure(EntityTypeBuilder<Scheduled> builder)
    {
        builder.ToTable("agendamento");

        builder.HasOne(x => x.User).WithMany(x => x.ListScheduled).HasForeignKey(x => x.UserId);

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

        builder.Property(x => x.UserId).HasColumnName("id_usuario");
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.UserId).HasColumnType("BIGINT");
        builder.Property(x => x.UserId).ValueGeneratedNever();

        builder.Property(x => x.DateTime).HasColumnName("data_hora");
        builder.Property(x => x.DateTime).IsRequired();
        builder.Property(x => x.DateTime).HasColumnType("DATETIME");
        builder.Property(x => x.DateTime).ValueGeneratedNever();

        builder.Property(x => x.Service).HasColumnName("servico");
        builder.Property(x => x.Service).IsRequired();
        builder.Property(x => x.Service).HasColumnType("INT");
        builder.Property(x => x.Service).ValueGeneratedNever();

        builder.Property(x => x.Status).HasColumnName("status");
        builder.Property(x => x.Status).HasColumnType("INT");
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Status).ValueGeneratedNever();

        builder.Property(x => x.Observation).HasColumnName("observacao");
        builder.Property(x => x.Observation).HasColumnType("VARCHAR(1000)");
        builder.Property(x => x.Observation).ValueGeneratedNever();
    }
}