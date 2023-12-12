
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MovimientoMedicamnetoRepository : GenericRepositoryB<MovimientoMedicamento>, IMovimientoMedicamentoInterface
{
    private readonly WebDbAppiContext _context;

    public MovimientoMedicamnetoRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync()
    {
        return await _context.Set<MovimientoMedicamento>()
        .Include(p => p.DetallesMovimientos)
        .ToListAsync();
    }

    public override async Task<MovimientoMedicamento> GetByIdAsync(int id)
    {
        return await _context.Set<MovimientoMedicamento>()
        .Include(p => p.DetallesMovimientos)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<MovimientoMedicamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.MovimientoMedicamentos as IQueryable<MovimientoMedicamento>;

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.DetallesMovimientos)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    public IEnumerable<object> ListaValorTotalMovimientoMedicamentos()
    {
        List<object> lstMoviMedicamentoPrecio = new ();
        var lstMedicamentos = _context.Set<Medicamento>()
        .ToList();
        var lstMedicametosMovi = _context.Set<MovimientoMedicamento>()
        .ToList();

        foreach (var lstMedic in lstMedicamentos)
        {
            foreach (var lstMoviMedi in lstMedicametosMovi)
            {
                if (lstMoviMedi.Id_medicamento == lstMedic.IdCodigo) {
                    lstMoviMedicamentoPrecio.Add(new {
                        IdCodigo = lstMoviMedi.IdCodigo,
                        Medicamento = lstMedic.Nombre,
                        Cantidad = lstMoviMedi.Cantidad,
                        Fecha = lstMoviMedi.Fecha,
                        PrecioTotalMovi = (lstMoviMedi.Cantidad * lstMedic.Precio)
                    });
                }   
            }
        }

        return lstMoviMedicamentoPrecio;
    }
}
