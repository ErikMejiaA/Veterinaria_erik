
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("Medicamentos");

        builder.Property(p => p.IdCodigo)
        .IsRequired();
        
        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.CantidadDisponible)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Precio)
        .IsRequired()
        .HasColumnType("double");

        builder.HasOne(p => p.Laboratorio)
        .WithMany(p => p.Medicamentos)
        .HasForeignKey(p => p.Id_laboratorio);
    }
}
