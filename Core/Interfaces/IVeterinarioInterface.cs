
using Core.Entities;

namespace Core.Interfaces;

public interface IVeterinarioInterface : IGenericInterfaceB<Veterinario>
{
    Task<IEnumerable<Veterinario>> GetAllVeterinariosEspecialidad(string especialidad);
        
}
