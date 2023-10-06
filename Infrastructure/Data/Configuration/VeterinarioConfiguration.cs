
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
{
    public void Configure(EntityTypeBuilder<Veterinario> builder)
    {
        builder.ToTable("Veterinarios");

        builder.Property(p => p.IdCodigo)
        .IsRequired();

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.CorreoElectronico)
        .IsRequired()
        .HasMaxLength(150);
        
        builder.Property(p => p.Especialidad)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.Telefono)
        .IsRequired()
        .HasMaxLength(15);

        builder.HasIndex(p => new {p.CorreoElectronico, p.Telefono})
        .IsUnique();
    }
}