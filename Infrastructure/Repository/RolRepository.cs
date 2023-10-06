
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class RolRepository : GenericRepositoryB<Rol>, IRolInterface
{
    private readonly WebDbAppiContext _context;

    public RolRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    //Implementacion de mas vetodos de sobrecarga override 
}
