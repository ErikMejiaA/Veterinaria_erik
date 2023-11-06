using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class CitaRepository : GenericRepositoryB<Cita>, ICitaInterface
{
    private readonly WebDbAppiContext _context;

    public CitaRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Set<Cita>()
        .Include(p => p.TratamientosMedicos)
        .ToListAsync();
    }

    public override async Task<Cita> GetByIdAsync(int id)
    {
        return await _context.Set<Cita>()
        .Include(p => p.TratamientosMedicos)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }
    
    public override async Task<(int totalRegistros, IEnumerable<Cita> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Citas as IQueryable<Cita>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Motivo.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.TratamientosMedicos)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    
}
