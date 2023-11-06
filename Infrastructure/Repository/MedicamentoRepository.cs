
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class MedicamentoRepository : GenericRepositoryB<Medicamento>, IMedicamentoInterface
{
    private readonly WebDbAppiContext _context;

    public MedicamentoRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Set<Medicamento>()
        .Include(p => p.MovimientosMedicamentos)
        .Include(p => p.DetallesMovimientos)
        .Include(p => p.MedicamentosProveedores)
        .Include(p => p.TratamientosMedicos)
        .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Set<Medicamento>()
        .Include(p => p.MovimientosMedicamentos)
        .Include(p => p.DetallesMovimientos)
        .Include(p => p.MedicamentosProveedores)
        .Include(p => p.TratamientosMedicos)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Medicamentos as IQueryable<Medicamento>;

        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.MovimientosMedicamentos)
                                .Include(p => p.DetallesMovimientos)
                                .Include(p => p.MedicamentosProveedores)
                                .Include(p => p.TratamientosMedicos)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    //COSULTAS
    public async Task<IEnumerable<Laboratorio>> GetAllMedicamentosSegunUnLab(string laboratorio)
    {
        var lstMedicamentosLab = _context.Set<Laboratorio>()
        .Include(p => p.Medicamentos)
        .Where(p => p.Nombre.ToLower().Contains(laboratorio.ToLower()))
        .ToListAsync();

        return await lstMedicamentosLab;
    }

    public async Task<IEnumerable<Medicamento>> GetAllMayoresA(double precio)
    {
        var lstMedicamentosXprecio = _context.Set<Medicamento>()
        .Where(p => p.Precio > precio)
        .ToListAsync();

        return await lstMedicamentosXprecio;
    }
}
