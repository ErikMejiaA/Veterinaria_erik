
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProveedorRepository : GenericRepositoryB<Proveedor>, IProveedorInterface
{
    private readonly WebDbAppiContext _context;

    public ProveedorRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    
}
