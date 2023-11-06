
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EspecieRepository : GenericRepositoryB<Especie>, IEspecieInterface
{
    private readonly WebDbAppiContext _context;

    public EspecieRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

     public override async Task<IEnumerable<Especie>> GetAllAsync()
    {
        return await _context.Set<Especie>()
        .Include(p => p.Mascotas)
        .Include(p => p.Razas)
        .ToListAsync();
    }

    public override async Task<Especie> GetByIdAsync(int id)
    {
        return await _context.Set<Especie>()
        .Include(p => p.Mascotas)
        .Include(p => p.Razas)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Especie> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Especies as IQueryable<Especie>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Mascotas)
                                .Include(p => p.Razas)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    
}
