
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class VeterinarioRepository : GenericRepositoryB<Veterinario>, IVeterinarioInterface
{
    private readonly WebDbAppiContext _context;

    public VeterinarioRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Veterinario>> GetAllAsync()
    {
        return await _context.Set<Veterinario>()
        .Include(p => p.Citas)
        .ToListAsync();
    }

    public override async Task<Veterinario> GetByIdAsync(int id)
    {
        return await _context.Set<Veterinario>()
        .Include(p => p.Citas)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Veterinarios as IQueryable<Veterinario>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Citas)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    //CONSULTAS
    public async Task<IEnumerable<Veterinario>> GetAllVeterinariosEspecialidad(string especialidad)
    {
        var lstVeterinarioEsp = _context.Set<Veterinario>()
        .Where(p => p.Especialidad.ToLower().Contains(especialidad.ToLower()))
        .ToListAsync();

        return await lstVeterinarioEsp;
    }
}
