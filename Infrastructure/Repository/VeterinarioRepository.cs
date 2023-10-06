
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class VeterinarioRepository : GenericRepositoryB<Veterinario>, IVeterinarioInterface
{
    private readonly WebDbAppiContext _context;

    public VeterinarioRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }
    
}
