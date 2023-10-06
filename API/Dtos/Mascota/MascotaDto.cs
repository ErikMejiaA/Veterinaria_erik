
using API.Dtos.Cita;

namespace API.Dtos.Mascota;

public class MascotaDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int Id_propietario { get; set; } 
    public int Id_especie { get; set; }
    public int Id_raza { get; set; }

    //public Propietario ? Propietario { get; set; }
    //public Especie ? Especie { get; set; }
    //public Raza ? Raza { get; set; }

    public List<CitaDto> ? Citas { get; set; }
         
}