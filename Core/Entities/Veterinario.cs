
namespace Core.Entities;

public class Veterinario : BaseEntityB
{
    public string ? Nombre { get; set; }
    public string ? CorreoElectronico { get; set; }
    public string ? Telefono { get; set; }
    public string ? Especialidad {  get; set; }

    public ICollection<Cita> ? Citas { get; set; }
        
}
