
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class TipoMovimientoRepository : GenericRepositoryB<TipoMovimiento>, ITipoMovimientoInterface
{
    private readonly WebDbAppiContext _context;

    public TipoMovimientoRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoMovimiento>> GetAllAsync()
    {
        return await _context.Set<TipoMovimiento>()
        .Include(p => p.MovimientosMedicamentos)
        .ToListAsync();
    }

     public override async Task<TipoMovimiento> GetByIdAsync(int id)
    {
        return await _context.Set<TipoMovimiento>()
        .Include(p => p.MovimientosMedicamentos)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoMovimiento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TiposMovimientos as IQueryable<TipoMovimiento>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.MovimientosMedicamentos)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    
}
