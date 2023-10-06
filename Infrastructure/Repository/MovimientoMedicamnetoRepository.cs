
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class MovimientoMedicamnetoRepository : GenericRepositoryB<MovimientoMedicamento>, IMovimientoMedicamentoInterface
{
    private readonly WebDbAppiContext _context;

    public MovimientoMedicamnetoRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    
}
