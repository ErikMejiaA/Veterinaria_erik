namespace Core.Entities;

public class Especie : BaseEntityB
{
    public string ? Nombre { get; set; }

    public ICollection<Mascota> ? Mascotas { get; set; }
    public ICollection<Raza> ? Razas { get; set; }
        
}
