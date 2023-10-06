
using API.Dtos.Mascota;

namespace API.Dtos.Propietario;
public class PropietarioDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public string ? CorreoElectronico { get; set; }
    public string ? Telefono { get; set; }

    public List<MascotaDto> ? Mascotas { get; set; }

        
}
