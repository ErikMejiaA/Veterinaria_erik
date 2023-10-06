
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
{
    public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
    {
       builder.ToTable("DetallesMovimientos");

        builder.Property(p => p.IdCodigo)
        .IsRequired();

        builder.Property(p => p.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Precio)
        .IsRequired()
        .HasColumnType("double");

        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.DetallesMovimientos)
        .HasForeignKey(p => p.Id_medicamento);

        builder.HasOne(p => p.MovimientoMedicamento)
        .WithMany(p => p.DetallesMovimientos)
        .HasForeignKey(p => p.Id_movimientoMedicamento);
    }
}
