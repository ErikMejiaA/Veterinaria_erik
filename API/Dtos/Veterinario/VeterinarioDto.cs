
using API.Dtos.Cita;

namespace API.Dtos.Veterinario;
public class VeterinarioDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public string ? CorreoElectronico { get; set; }
    public string ? Telefono { get; set; }
    public string ? Especialidad {  get; set; }

    public List<CitaDto> ? Citas { get; set; }
        
}
