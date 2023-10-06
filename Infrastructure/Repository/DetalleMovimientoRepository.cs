
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class DetalleMovimientoRepository : GenericRepositoryB<DetalleMovimiento>, IDetalleMovimientoInterface
{
    private readonly WebDbAppiContext _context;

    public DetalleMovimientoRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }
    
}
