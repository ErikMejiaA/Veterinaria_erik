
using API.Dtos.Mascota;
using API.Dtos.Raza;

namespace API.Dtos.Especie;
public class EspecieXmascotaDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public List<MascotaConsultaDto> ? Mascotas { get; set; }
}