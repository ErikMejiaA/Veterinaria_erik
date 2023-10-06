
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
{
    public void Configure(EntityTypeBuilder<Mascota> builder)
    {
        builder.ToTable("Mascotas");

        builder.Property(p => p.IdCodigo)
        .IsRequired();
        
        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.FechaNacimiento)
        .IsRequired()
        .HasColumnType("date");

        builder.HasOne(p => p.Propietario)
        .WithMany(p => p.Mascotas)
        .HasForeignKey(p => p.Id_propietario);

        builder.HasOne(p => p.Especie)
        .WithMany(p => p.Mascotas)
        .HasForeignKey(p => p.Id_especie);

        builder.HasOne(p => p.Raza)
        .WithMany(p => p.Mascotas)
        .HasForeignKey(p => p.Id_raza);


    }
}
