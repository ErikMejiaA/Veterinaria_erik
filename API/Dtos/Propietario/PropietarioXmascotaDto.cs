
using API.Dtos.Mascota;

namespace API.Dtos.Propietario;
public class PropietarioXmascotaDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public List<MascotaConsultaDto> ? Mascotas { get; set; }  
}
