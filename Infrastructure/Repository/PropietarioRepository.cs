
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class PropietarioRepository : GenericRepositoryB<Propietario>, IPropietarioInterface
{
    private readonly WebDbAppiContext _context;

    public PropietarioRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    
}
