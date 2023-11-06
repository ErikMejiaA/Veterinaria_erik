
using Core.Entities;

namespace Core.Interfaces;

public interface IPropietarioInterface : IGenericInterfaceB<Propietario>
{
    Task<IEnumerable<Propietario>> GetAllMascotasXpropietario();
        
}
