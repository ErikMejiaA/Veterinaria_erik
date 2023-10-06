using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
{
    public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
    {
        builder.ToTable("TiposMovimientos");

        builder.Property(p => p.IdCodigo)
        .IsRequired();
        
        builder.Property(P => P.Descripcion)
        .IsRequired()
        .HasMaxLength(200);
    }
}
