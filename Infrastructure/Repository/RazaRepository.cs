
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class RazaRepository : GenericRepositoryB<Raza>, IRazaInterface
{
    private readonly WebDbAppiContext _context;

    public RazaRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    
}
