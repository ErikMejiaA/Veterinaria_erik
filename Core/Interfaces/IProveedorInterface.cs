
using Core.Entities;

namespace Core.Interfaces;

public interface IProveedorInterface : IGenericInterfaceB<Proveedor>
{
    IEnumerable<Proveedor> GetListaProveedoresMedicamento(string medicamentoo);
        
}
