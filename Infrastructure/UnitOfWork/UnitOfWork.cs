using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWorkInterface, IDisposable
{
    //definimos el constructor y las variabales de los repositorios creados 
    private readonly WebDbAppiContext _context;
    private RolRepository ? _roles;
    private UsuarioRepository ? _usuarios;
    private UsuariosRolesRepository ? _usuariosRoles;

    public UnitOfWork(WebDbAppiContext context)
    {
        _context = context;
    }

    
    public IRolInterface Roles
    {
        get
        {
            if (_roles == null) {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUsuarioInterface Usuarios
    {
        get
        {
            if (_usuarios == null) {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public IUsuariosRolesInterface UsuariosRoles
    {
        get
        {
            if (_usuariosRoles == null) {
                _usuariosRoles = new UsuariosRolesRepository(_context);
            }
            return _usuariosRoles;

        }
    }

    public void Dispose()
    {
        _context.Dispose(); //liberar memoria 
    }


    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync(); //para guardar los cambios en la base de datos 
    }
}
