
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class PropietarioRepository : GenericRepositoryB<Propietario>, IPropietarioInterface
{
    private readonly WebDbAppiContext _context;

    public PropietarioRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Set<Propietario>()
        .Include(p => p.Mascotas)
        .ToListAsync();
    }

    public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Set<Propietario>()
        .Include(p => p.Mascotas)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Propietario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Propietarios as IQueryable<Propietario>;

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

    //CONSULTAS
    public async Task<IEnumerable<Propietario>> GetAllMascotasXpropietario()
    {
        var lstMascotasXpropietario = _context.Set<Propietario>()
        .Include(p => p.Mascotas)
        .Where(p => !(p.Mascotas.Count() == 0 || p.Mascotas == null))
        .ToListAsync();

        return await lstMascotasXpropietario;
    }
}
