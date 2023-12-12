
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProveedorRepository : GenericRepositoryB<Proveedor>, IProveedorInterface
{
    private readonly WebDbAppiContext _context;

    public ProveedorRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Set<Proveedor>()
        .Include(p => p.MedicamentosProveedores)
        .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Set<Proveedor>()
        .Include(p => p.MedicamentosProveedores)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Proveedores as IQueryable<Proveedor>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.MedicamentosProveedores)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    public IEnumerable<Proveedor> GetListaProveedoresMedicamento(string medicamentoo)
    {
        var lstMedicamentos = _context.Set<Medicamento>()
        .Where(p => p.Nombre.ToLower() == medicamentoo.ToLower())
        .First();
        
        var lstProveedorMedi = _context.Set<Proveedor>()
        .Where(p => p.MedicamentosProveedores.Any(p => p.Id_medicamento == lstMedicamentos.IdCodigo))
        .ToList();

        return lstProveedorMedi;
    }
}
