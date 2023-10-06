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

    public override async Task<(int totalRegistros, IEnumerable<Cita> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Citas as IQueryable<Cita>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Motivo.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    
}
