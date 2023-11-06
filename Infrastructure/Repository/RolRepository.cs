
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class RolRepository : GenericRepositoryB<Rol>, IRolInterface
{
    private readonly WebDbAppiContext _context;

    public RolRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    //Implementacion de mas vetodos de sobrecarga override 

    public override async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await _context.Set<Rol>()
        .Include(p => p.Usuarios)
        .ToListAsync();
    }

    public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Set<Rol>()
        .Include(p => p.Usuarios)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Rol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Roles as IQueryable<Rol>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Usuarios)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
    
}
