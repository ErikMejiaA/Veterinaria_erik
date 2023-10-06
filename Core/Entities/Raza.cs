
namespace Core.Entities;
public class Raza : BaseEntityB
{
    public string ? Nombre { get; set; }
    public int Id_especie { get; set; }
    public Especie ? Especie { get; set; }

    public ICollection<Mascota> ? Mascotas { get; set; }
    
        
}
