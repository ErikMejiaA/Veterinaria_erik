
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class TipoMovimientoRepository : GenericRepositoryB<TipoMovimiento>, ITipoMovimientoInterface
{
    private readonly WebDbAppiContext _context;

    public TipoMovimientoRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    
}
