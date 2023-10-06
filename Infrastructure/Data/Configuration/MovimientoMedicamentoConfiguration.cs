
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
{
    public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
    {
        builder.ToTable("MovimientosMedicamentos");

        builder.Property(p => p.IdCodigo)
        .IsRequired();

        builder.Property(p => p.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Fecha)
        .IsRequired()
        .HasColumnType("date");
        
        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.MovimientosMedicamentos)
        .HasForeignKey(p => p.Id_medicamento);

        builder.HasOne(p => p.TipoMovimiento)
        .WithMany(p => p.MovimientosMedicamentos)
        .HasForeignKey(p => p.Id_tipo);
    }
}
