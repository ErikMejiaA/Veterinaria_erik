
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class MedicamentoRepository : GenericRepositoryB<Medicamento>, IMedicamentoInterface
{
    private readonly WebDbAppiContext _context;

    public MedicamentoRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }
    

    
}
