
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MedicamentoProveedorConfiguration : IEntityTypeConfiguration<MedicamentoProveedor>
{
    public void Configure(EntityTypeBuilder<MedicamentoProveedor> builder)
    {
        builder.ToTable("MedicamentosProveedor");
        
        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.MedicamentosProveedores)
        .HasForeignKey(p => p.Id_medicamento);

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.MedicamentosProveedores)
        .HasForeignKey(p => p.Id_proveedor);
    }
}
