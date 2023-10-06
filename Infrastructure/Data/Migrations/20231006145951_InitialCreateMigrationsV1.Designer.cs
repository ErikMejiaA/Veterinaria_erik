﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(WebDbAppiContext))]
    [Migration("20231006145951_InitialCreateMigrationsV1")]
    partial class InitialCreateMigrationsV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("time(6)");

                    b.Property<int>("Id_mascota")
                        .HasColumnType("int");

                    b.Property<int>("Id_veterinario")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Id_mascota");

                    b.HasIndex("Id_veterinario");

                    b.ToTable("Citas", (string)null);
                });

            modelBuilder.Entity("Core.Entities.DetalleMovimiento", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Id_medicamento")
                        .HasColumnType("int");

                    b.Property<int>("Id_movimientoMedicamento")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Id_medicamento");

                    b.HasIndex("Id_movimientoMedicamento");

                    b.ToTable("DetallesMovimientos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Especie", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdCodigo");

                    b.ToTable("Especies", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Laboratorio", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Laboratorios", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<int>("Id_especie")
                        .HasColumnType("int");

                    b.Property<int>("Id_propietario")
                        .HasColumnType("int");

                    b.Property<int>("Id_raza")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Id_especie");

                    b.HasIndex("Id_propietario");

                    b.HasIndex("Id_raza");

                    b.ToTable("Mascotas", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Medicamento", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("int");

                    b.Property<int>("Id_laboratorio")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Id_laboratorio");

                    b.ToTable("Medicamentos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.MedicamentoProveedor", b =>
                {
                    b.Property<int>("Id_proveedor")
                        .HasColumnType("int");

                    b.Property<int>("Id_medicamento")
                        .HasColumnType("int");

                    b.HasKey("Id_proveedor", "Id_medicamento");

                    b.HasIndex("Id_medicamento");

                    b.ToTable("MedicamentosProveedor", (string)null);
                });

            modelBuilder.Entity("Core.Entities.MovimientoMedicamento", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("Id_medicamento")
                        .HasColumnType("int");

                    b.Property<int>("Id_tipo")
                        .HasColumnType("int");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Id_medicamento");

                    b.HasIndex("Id_tipo");

                    b.ToTable("MovimientosMedicamentos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Propietario", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdCodigo");

                    b.ToTable("Propietarios", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdCodigo");

                    b.ToTable("Proveedores", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Raza", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Id_especie")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Id_especie");

                    b.ToTable("Razas", (string)null);
                });

            modelBuilder.Entity("Core.Entities.RefreshToken", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdCodigo");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdCodigo");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoMovimiento", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdCodigo");

                    b.ToTable("TiposMovimientos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TratamientoMedico", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Dosis")
                        .HasColumnType("double");

                    b.Property<DateTime>("FechaAdministracion")
                        .HasColumnType("date");

                    b.Property<int>("Id_Cita")
                        .HasColumnType("int");

                    b.Property<int>("Id_medicamento")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Id_Cita");

                    b.HasIndex("Id_medicamento");

                    b.ToTable("TratamientoMedico", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Username", "Email")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Core.Entities.UsuariosRoles", b =>
                {
                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("UsuariosRoles");
                });

            modelBuilder.Entity("Core.Entities.Veterinario", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("CorreoElectronico", "Telefono")
                        .IsUnique();

                    b.ToTable("Veterinarios", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.HasOne("Core.Entities.Mascota", "Mascota")
                        .WithMany("Citas")
                        .HasForeignKey("Id_mascota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Veterinario", "Veterinario")
                        .WithMany("Citas")
                        .HasForeignKey("Id_veterinario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("Core.Entities.DetalleMovimiento", b =>
                {
                    b.HasOne("Core.Entities.Medicamento", "Medicamento")
                        .WithMany("DetallesMovimientos")
                        .HasForeignKey("Id_medicamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.MovimientoMedicamento", "MovimientoMedicamento")
                        .WithMany("DetallesMovimientos")
                        .HasForeignKey("Id_movimientoMedicamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("MovimientoMedicamento");
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.HasOne("Core.Entities.Especie", "Especie")
                        .WithMany("Mascotas")
                        .HasForeignKey("Id_especie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Propietario", "Propietario")
                        .WithMany("Mascotas")
                        .HasForeignKey("Id_propietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Raza", "Raza")
                        .WithMany("Mascotas")
                        .HasForeignKey("Id_raza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");

                    b.Navigation("Propietario");

                    b.Navigation("Raza");
                });

            modelBuilder.Entity("Core.Entities.Medicamento", b =>
                {
                    b.HasOne("Core.Entities.Laboratorio", "Laboratorio")
                        .WithMany("Medicamentos")
                        .HasForeignKey("Id_laboratorio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratorio");
                });

            modelBuilder.Entity("Core.Entities.MedicamentoProveedor", b =>
                {
                    b.HasOne("Core.Entities.Medicamento", "Medicamento")
                        .WithMany("MedicamentosProveedores")
                        .HasForeignKey("Id_medicamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Proveedor", "Proveedor")
                        .WithMany("MedicamentosProveedores")
                        .HasForeignKey("Id_proveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Core.Entities.MovimientoMedicamento", b =>
                {
                    b.HasOne("Core.Entities.Medicamento", "Medicamento")
                        .WithMany("MovimientosMedicamentos")
                        .HasForeignKey("Id_medicamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoMovimiento", "TipoMovimiento")
                        .WithMany("MovimientosMedicamentos")
                        .HasForeignKey("Id_tipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("TipoMovimiento");
                });

            modelBuilder.Entity("Core.Entities.Raza", b =>
                {
                    b.HasOne("Core.Entities.Especie", "Especie")
                        .WithMany("Razas")
                        .HasForeignKey("Id_especie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("Core.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Entities.Usuario", "Usuario")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Entities.TratamientoMedico", b =>
                {
                    b.HasOne("Core.Entities.Cita", "Cita")
                        .WithMany("TratamientosMedicos")
                        .HasForeignKey("Id_Cita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Medicamento", "Medicamento")
                        .WithMany("TratamientosMedicos")
                        .HasForeignKey("Id_medicamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("Core.Entities.UsuariosRoles", b =>
                {
                    b.HasOne("Core.Entities.Rol", "Rol")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Usuario", "Usuario")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.Navigation("TratamientosMedicos");
                });

            modelBuilder.Entity("Core.Entities.Especie", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("Razas");
                });

            modelBuilder.Entity("Core.Entities.Laboratorio", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Core.Entities.Medicamento", b =>
                {
                    b.Navigation("DetallesMovimientos");

                    b.Navigation("MedicamentosProveedores");

                    b.Navigation("MovimientosMedicamentos");

                    b.Navigation("TratamientosMedicos");
                });

            modelBuilder.Entity("Core.Entities.MovimientoMedicamento", b =>
                {
                    b.Navigation("DetallesMovimientos");
                });

            modelBuilder.Entity("Core.Entities.Propietario", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.Navigation("MedicamentosProveedores");
                });

            modelBuilder.Entity("Core.Entities.Raza", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Navigation("UsuariosRoles");
                });

            modelBuilder.Entity("Core.Entities.TipoMovimiento", b =>
                {
                    b.Navigation("MovimientosMedicamentos");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsuariosRoles");
                });

            modelBuilder.Entity("Core.Entities.Veterinario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}