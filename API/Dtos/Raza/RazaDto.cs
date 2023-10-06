
using API.Dtos.Mascota;

namespace API.Dtos.Raza;
public class RazaDto
{
    public int IdCodigo { get; set; }
    public string ? Nombre { get; set; }
    public int Id_especie { get; set; }
    //public Especie ? Especie { get; set; }

    public List<MascotaDto> ? Mascotas { get; set; }
        
}
