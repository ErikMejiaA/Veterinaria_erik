namespace Core.Entities;
public class Propietario : BaseEntityB
{
    public string ? Nombre { get; set; }
    public string ? CorreoElectronico { get; set; }
    public string ? Telefono { get; set; }

    public ICollection<Mascota> ? Mascotas { get; set; }
    
        
}
