
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class RazaConfiguration : IEntityTypeConfiguration<Raza>
{
    public void Configure(EntityTypeBuilder<Raza> builder)
    {
        builder.ToTable("Razas");

        builder.Property(p => p.IdCodigo)
        .IsRequired();
        
        builder.HasOne(p => p.Especie)
        .WithMany(p => p.Razas)
        .HasForeignKey(p => p.Id_especie);
    }
}
