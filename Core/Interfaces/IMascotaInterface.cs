
using Core.Entities;

namespace Core.Interfaces;
public interface IMascotaInterface :  IGenericInterfaceB<Mascota>
{
    Task<IEnumerable<Especie>> GetAllMascotasFelinas(string especie);
    Task<IEnumerable<Mascota>> GetAllMascotasPorVacunacion(string motivo);
    Task<IEnumerable<Especie>> GetAllMascotasEspecies();
    IEnumerable<Mascota> GetAllMascotasPorVeterinario(string Veterinario);
        
}
