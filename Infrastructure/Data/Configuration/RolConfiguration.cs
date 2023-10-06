using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Roles");

        builder.Property(p => p.IdCodigo)
        .IsRequired();

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(200);
    }
}
