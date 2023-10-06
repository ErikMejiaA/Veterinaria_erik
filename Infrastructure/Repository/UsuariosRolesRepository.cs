using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class UsuariosRolesRepository : IUsuariosRolesInterface
{
    private readonly WebDbAppiContext _context;

    public UsuariosRolesRepository(WebDbAppiContext context)
    {
        _context = context;
    }

    //implementacion de los metodos de la Interfaces
    public void Add(UsuariosRoles entity)
    {
        _context.Set<UsuariosRoles>().Add(entity);
    }

    public void AddRange(IEnumerable<UsuariosRoles> entities)
    {
        _context.Set<UsuariosRoles>().AddRange(entities);
    }

    public IEnumerable<UsuariosRoles> Find(Expression<Func<UsuariosRoles, bool>> expression)
    {
        return _context.Set<UsuariosRoles>().Where(expression);
    }

    public async Task<IEnumerable<UsuariosRoles>> GetAllAsync()
    {
        return await _context.Set<UsuariosRoles>().ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<UsuariosRoles> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<UsuariosRoles>().CountAsync();
        var registros = await _context.Set<UsuariosRoles>()
                                                        .Skip((pageIndex - 1) * pageSize)
                                                        .Take(pageSize)
                                                        .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<UsuariosRoles> GetByIdAsync(int idUsua, int idRol)
    {
        return await _context.Set<UsuariosRoles>().FirstOrDefaultAsync(p => (p.UsuarioId == idUsua && p.RolId == idRol));
    }

    public void Remove(UsuariosRoles entity)
    {
        _context.Set<UsuariosRoles>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<UsuariosRoles> entities)
    {
        _context.Set<UsuariosRoles>().RemoveRange(entities);
    }

    public void Update(UsuariosRoles entity)
    {
        _context.Set<UsuariosRoles>().Update(entity);
    }
        
}
