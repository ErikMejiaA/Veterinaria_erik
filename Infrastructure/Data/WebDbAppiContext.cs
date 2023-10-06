
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class WebDbAppiContext : DbContext
{
    public WebDbAppiContext(DbContextOptions<WebDbAppiContext> options) : base(options)
    {

    }

    //aqui van los DbSeT<>
    public DbSet<Rol> ? Roles { get; set; }
    public DbSet<Usuario> ? Usuarios { get; set; }
    public DbSet<UsuariosRoles> ? UsuariosRoles { get; set; }
    public DbSet<RefreshToken> ? RefreshTokens { get; set; }
    public DbSet<Cita> ? Citas { get; set; }
    public DbSet<DetalleMovimiento> ? DetallesMovimientos { get; set; }
    public DbSet<Especie> ? Especies { get; set; }
    public DbSet<Laboratorio> ? Laboratorios { get; set; }
    public DbSet<Mascota> ? Mascotas { get; set; }
    public DbSet<Medicamento> ? Medicamentos { get; set; }
    public DbSet<MedicamentoProveedor> ? MedicamentosProveedores { get; set; }
    public DbSet<MovimientoMedicamento> ? MovimientoMedicamentos { get; set; }
    public DbSet<Propietario> ? Propietarios { get; set; }
    public DbSet<Proveedor> ? Proveedores { get; set; }
    public DbSet<Raza> ? Razas { get; set; }
    public DbSet<TipoMovimiento> ? TiposMovimientos { get; set; }
    public DbSet<TratamientoMedico> ? TratamientosMedicos { get; set; }
    public DbSet<Veterinario> ? Veterinarios { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //para definir llaves primarias compuestas foraneas  
        modelBuilder.Entity<MedicamentoProveedor>().HasKey(p => new {p.Id_proveedor , p.Id_medicamento});

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    internal void SaveAsync()
    {
        throw new NotImplementedException();
    }
}
