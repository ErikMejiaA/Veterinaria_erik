
using Core.Entities;

namespace Core.Interfaces;

public interface IRazaInterface : IGenericInterfaceB<Raza>
{
    IEnumerable<object> GetAllRazasCantidadMascotas();
        
}
