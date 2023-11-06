
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class RazaRepository : GenericRepositoryB<Raza>, IRazaInterface
{
    private readonly WebDbAppiContext _context;

    public RazaRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Raza>> GetAllAsync()
    {
        return await _context.Set<Raza>()
        .Include(p => p.Mascotas)
        .ToListAsync();
    }

    public override async Task<Raza> GetByIdAsync(int id)
    {
        return await _context.Set<Raza>()
        .Include(p => p.Mascotas)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Raza> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Razas as IQueryable<Raza>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Mascotas)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    
}
