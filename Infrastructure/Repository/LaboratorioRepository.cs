
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class LaboratorioRepository : GenericRepositoryB<Laboratorio>, ILaboratorioInterface
{
    private readonly WebDbAppiContext _context;

    public LaboratorioRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    
}
