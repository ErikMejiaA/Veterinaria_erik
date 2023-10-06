
using API.Dtos.Mascota;
using API.Dtos.Raza;

namespace API.Dtos.Especie;
public class EspecieDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }

    public List<MascotaDto> ? Mascotas { get; set; }
    public List<RazaDto> ? Razas { get; set; }
        
}
