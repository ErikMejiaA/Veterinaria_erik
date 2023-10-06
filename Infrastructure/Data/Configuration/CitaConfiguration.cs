
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("Citas");

        builder.Property(p => p.IdCodigo)
        .IsRequired();

        builder.Property(p => p.Fecha)
        .IsRequired()
        .HasColumnType("date");

        builder.Property(p => p.Hora)
        .IsRequired();

        builder.Property(p => p.Motivo)
        .IsRequired()
        .HasMaxLength(200);

        builder.HasOne(p => p.Mascota)
        .WithMany(p => p.Citas)
        .HasForeignKey(p => p.Id_mascota);

        builder.HasOne(p => p.Veterinario)
        .WithMany(p => p.Citas)
        .HasForeignKey(p => p.Id_veterinario);

    }
}
