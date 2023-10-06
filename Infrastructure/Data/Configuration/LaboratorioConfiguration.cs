
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
{
    public void Configure(EntityTypeBuilder<Laboratorio> builder)
    {
        builder.ToTable("Laboratorios");

        builder.Property(p => p.IdCodigo)
        .IsRequired();

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.Direccion)
        .IsRequired()
        .HasMaxLength(200);

        builder.Property(p => p.Telefono)
        .IsRequired()
        .HasMaxLength(15);

        builder.HasIndex(p => p.Nombre)
        .IsUnique();

    }
}
