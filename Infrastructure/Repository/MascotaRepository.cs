
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class MascotaRepository : GenericRepositoryB<Mascota>, IMascotaInterface
{
    private readonly WebDbAppiContext _context;

    public MascotaRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    
}
