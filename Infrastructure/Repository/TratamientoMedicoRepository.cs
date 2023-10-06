
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class TratamientoMedicoRepository : GenericRepositoryB<TratamientoMedico>, ITrtamientoMedicoInterface
{
    private readonly WebDbAppiContext _context;

    public TratamientoMedicoRepository(WebDbAppiContext context) : base(context)
    {
        _context = context;
    }

    
}
