
namespace Core.Entities;
public class Mascota : BaseEntityB
{
    public string ? Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int Id_propietario { get; set; } 
    public int Id_especie { get; set; }
    public int Id_raza { get; set; }

    public Propietario ? Propietario { get; set; }
    public Especie ? Especie { get; set; }
    public Raza ? Raza { get; set; }

    public ICollection<Cita> ? Citas { get; set; }
        
}
