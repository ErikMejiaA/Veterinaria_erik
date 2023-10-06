
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
{
    public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
    {
        builder.ToTable("TratamientoMedico");

        builder.Property(p => p.IdCodigo)
        .IsRequired();
        
        builder.Property(P => P.Dosis)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(P => P.FechaAdministracion)
        .IsRequired()
        .HasColumnType("date");

        builder.Property(P => P.Observacion)
        .IsRequired()
        .HasMaxLength(200);

        builder.HasOne(p => p.Cita)
        .WithMany(p => p.TratamientosMedicos)
        .HasForeignKey(p => p.Id_Cita);

        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.TratamientosMedicos)
        .HasForeignKey(p => p.Id_medicamento);


    }
}
