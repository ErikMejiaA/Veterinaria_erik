
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
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //para definir llaves primarias compuestas foraneas  
        //modelBuilder.Entity<Entidad>().HasKey(p => new {p.id1 , p.id2});

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    internal void SaveAsync()
    {
        throw new NotImplementedException();
    }
}
